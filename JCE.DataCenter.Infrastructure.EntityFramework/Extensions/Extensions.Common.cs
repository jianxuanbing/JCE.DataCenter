/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Extensions
 * 文件名：Extensions
 * 版本号：v1.0.0.0
 * 唯一标识：91013cad-8128-4796-9502-e6f03731a2e0
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/13 23:20:34
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/13 23:20:34
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
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using JCE.Utils.Logging;
using JCE.DataCenter.Infrastructure.Domain.Entities;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Extensions
{
    /// <summary>
    /// 通用扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 更新指定字段
        /// 忽略其他项，直接更新字段
        /// 兼容对象存在上下文处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="entity"></param>
        /// <param name="isSame"></param>
        /// <param name="propertyNames"></param>
        public static void UpdateField<T, TDbContext>(this TDbContext dbContext, T entity, Func<T, bool> isSame,
            params string[] propertyNames) where TDbContext : DbContext, new() where T : class
        {
            var db = CurrentDbContext<TDbContext>();
            db.Entry(entity).State = EntityState.Detached;
            var attachedEntity = db.Set<T>().Local.SingleOrDefault(isSame);
            if (attachedEntity != null)
            {
                //对象存在上下文中
                var attachedEntry = db.Entry(attachedEntity);
                attachedEntry.CurrentValues.SetValues(entity);
            }
            else
            {
                //对象不存在上下文中
                UpdateField<T, TDbContext>(dbContext,entity,propertyNames);    
            }
        }

        /// <summary>
        /// 更新指定字段
        /// 忽略其他项，直接更新字段
        /// 当对象存在上下文会报错
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        public static void UpdateField<T, TDbContext>(this TDbContext dbContext, T entity, params string[] propertyNames)
            where TDbContext : DbContext, new() where T : class
        {
            var db = CurrentDbContext<TDbContext>();
            db.Set<T>().Attach(entity);
            var setEntry = ((IObjectContextAdapter) db).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
            foreach (var propertyName in propertyNames)
            {
                setEntry.SetModifiedProperty(propertyName);
            }
        }


        /// <summary>
        /// EF 预热处理
        /// </summary>
        /// <param name="dbContext">数据上下文</param>
        public static void GenerateViews(this DbContext dbContext)
        {
            var objectContext = ((IObjectContextAdapter) dbContext).ObjectContext;
            var mappingCollection =
                (StorageMappingItemCollection) objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            mappingCollection.GenerateViews(new List<EdmSchemaError>());
        }

        /// <summary>
        /// 线程级 缓存 数据库
        /// </summary>
        /// <typeparam name="TDbContext">数据库上文类型</typeparam>
        /// <returns></returns>
        public static TDbContext CurrentDbContext<TDbContext>() where TDbContext : DbContext, new()
        {
            var name = typeof(TDbContext).FullName;
            var context = CallContext.GetData(name) as TDbContext;
            if (context == null)
            {
                context=new TDbContext();
                CallContext.SetData(name,context);
            }
            return context;
        }

        /// <summary>
        /// 事务期间读取和修改可变数据
        /// 主要用于nolock读取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T NoLockFunc<T, TDbContext>(this TDbContext dbContext, Func<TDbContext, T> func)
            where TDbContext : DbContext
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            };
            using (new TransactionScope(TransactionScopeOption.Required,transactionOptions))
            {
                try
                {
                    return func(dbContext);
                }
                catch (Exception ex)
                {
                    LogManager.GetLogger(dbContext.GetType()).Error(ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// 如果存在环境事务，直接取环境事务，如果不存在，则创建新的事务执行
        /// 省略事务提交步骤
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="dbContext"></param>
        /// <param name="func"></param>
        /// <param name="transactionScopeOption"></param>
        /// <returns></returns>
        public static T TransExecute<T, TDbContext>(this TDbContext dbContext, Func<TDbContext, T> func,
            TransactionScopeOption transactionScopeOption = TransactionScopeOption.Required)
            where TDbContext : DbContext
        {
            using (var trans=new TransactionScope(transactionScopeOption))
            {
                var rst = func(dbContext);
                trans.Complete();
                return rst;
            }
        }
    }
}
