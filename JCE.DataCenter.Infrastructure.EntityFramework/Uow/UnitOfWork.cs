/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Uow
 * 文件名：UnitOfWork
 * 版本号：v1.0.0.0
 * 唯一标识：c01bbbfb-3057-4fa5-9186-5ae1f5406556
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 12:42:29
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 12:42:29
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JCE.Utils;
using JCE.DataCenter.Infrastructure.Domain.Uow;
using JCE.DataCenter.Infrastructure.EntityFramework.Auditing;
using JCE.DataCenter.Infrastructure.EntityFramework.Exceptions;
using JCE.DataCenter.Infrastructure.EntityFramework.Logs;
using JCE.DataCenter.Infrastructure.EntityFramework.Map;
using JCE.DataCenter.Logs.Log4Net;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Uow
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnitOfWork:DbContext,IUnitOfWork
    {
        /// <summary>
        /// 启动标识
        /// </summary>
        private bool IsStart { get; set; }

        /// <summary>
        /// EF日志操作
        /// </summary>
        private EfLog _log;

        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// 初始化一个<see cref="UnitOfWork"/>类型的实例
        /// </summary>
        /// <param name="connectionName">数据库连接字符串的名称</param>
        protected UnitOfWork(string connectionName):base(connectionName)
        {
            TraceId = Guid.NewGuid().ToString();
            WriteLog();
            Database.SetInitializer<UnitOfWork>(null);            
        }

        /// <summary>
        /// 写日志
        /// </summary>
        private void WriteLog()
        {
            Database.Log = log =>
            {
                GetLog().Write(log);
            };
        }

        /// <summary>
        /// 获取日志记录器
        /// </summary>
        /// <returns></returns>
        protected virtual EfLog GetLog()
        {
            return _log ?? (_log = new EfLog(TraceId, Log.GetLog("SqlTraceLog")));
        }

        #region Start(启动)
        public void Start()
        {
            IsStart = true;
        }
        #endregion

        #region Commit(提交更新)
        /// <summary>
        /// 提交更新
        /// </summary>
        public void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException("当前数据已被更新，请刷新后重试", ex);
            }
            catch (DbEntityValidationException ex)
            {
                throw new EfValidationException(ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IsStart = false;
            }
        }
        #endregion

        #region CommitByStart(通过启动标识执行提交)
        /// <summary>
        /// 通过启动标识执行提交，如果已启动，则不提交
        /// </summary>
        internal void CommitByStart()
        {
            if (IsStart)
            {
                return;
            }
            Commit();
        }
        #endregion

        #region OnModelCreating(配置映射)
        /// <summary>
        /// 配置映射
        /// </summary>
        /// <param name="modelBuilder">数据实体构建器</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            foreach (IMap mapper in GetMaps())
            {
                mapper.AddTo(modelBuilder.Configurations);
            }
            Filter(modelBuilder);
        }

        /// <summary>
        /// 获取映射配置
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IMap> GetMaps()
        {
            var result = new List<IMap>();
            foreach (Assembly assembly in GetAssemblies())
            {
                result.AddRange(Reflection.GetByInterface<IMap>(assembly));
            }
            return result;
        }

        /// <summary>
        /// 获取定义映射配置的程序集列表
        /// </summary>
        /// <returns></returns>
        protected virtual Assembly[] GetAssemblies()
        {
            return new[] { GetType().Assembly };
        }

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="modelBuilder">数据实体构建器</param>
        private void Filter(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Filter<ISoftDelete, bool>(EfFilterNames.SoftDelete, entity => entity.IsDeleted, false);
        }
        #endregion

        #region Init(初始化工作单元列表)
        /// <summary>
        /// 初始化工作单元列表
        /// </summary>
        /// <param name="unitOfWorks">工作单元列表</param>
        public static void Init(params IUnitOfWork[] unitOfWorks)
        {
            foreach (IUnitOfWork unitOfWork in unitOfWorks)
            {
                InitUnitOfWork(unitOfWork);
            }
        }

        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        private static void InitUnitOfWork(IUnitOfWork unitOfWork)
        {
            using (unitOfWork)
            {
                var adapter = unitOfWork as IObjectContextAdapter;
                if (adapter == null)
                {
                    return;
                }
                var objectContext = adapter.ObjectContext;
                var mappingCollection =
                    (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }
        }
        #endregion

        #region SaveChanges(保存更改)
        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        public sealed override int SaveChanges()
        {
            SaveChangesBefore();
            var result = base.SaveChanges();
            return SaveChangesAfter(result);
        }

        /// <summary>
        /// 保存更改前操作
        /// </summary>
        protected virtual void SaveChangesBefore()
        {
            foreach (DbEntityEntry entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        InterceptAddedOperation(entry);
                        break;
                    case EntityState.Modified:
                        InterceptModifiedOperation(entry);
                        break;
                    case EntityState.Deleted:
                        InterceptDeletedOperation(entry);
                        break;
                }
            }
        }

        /// <summary>
        /// 拦截添加操作
        /// </summary>
        /// <param name="entry">数据实体</param>
        protected virtual void InterceptAddedOperation(DbEntityEntry entry)
        {
            InitCreationAudited(entry);
            InitModificationAudited(entry);
        }

        /// <summary>
        /// 初始化创建审计信息
        /// </summary>
        /// <param name="entry">数据实体</param>
        private void InitCreationAudited(DbEntityEntry entry)
        {
            CreationAuditedInitializer.Init(entry);
        }

        /// <summary>
        /// 初始化修改审计信息
        /// </summary>
        /// <param name="entry">数据实体</param>
        private void InitModificationAudited(DbEntityEntry entry)
        {
            ModificationAuditedInitializer.Init(entry);
        }

        /// <summary>
        /// 初始化修改忽略信息
        /// </summary>
        /// <param name="entry">数据实体</param>
        private void InitModificationIgnore(DbEntityEntry entry)
        {
            ModificationIgnoreInitializer.Init(entry);
        }

        /// <summary>
        /// 拦截修改操作
        /// </summary>
        /// <param name="entry">数据实体</param>
        protected virtual void InterceptModifiedOperation(DbEntityEntry entry)
        {
            InitModificationAudited(entry);
            InitModificationIgnore(entry);
        }

        /// <summary>
        /// 拦截删除操作
        /// </summary>
        /// <param name="entry">数据实体</param>
        protected virtual void InterceptDeletedOperation(DbEntityEntry entry)
        {

        }

        /// <summary>
        /// 保存更改后操作
        /// </summary>
        /// <param name="result">影响的行数</param>
        /// <returns></returns>
        protected virtual int SaveChangesAfter(int result)
        {
            return result;
        }
        #endregion
    }
}
