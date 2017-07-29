/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Repositories
 * 文件名：Repository
 * 版本号：v1.0.0.0
 * 唯一标识：8ea97954-23e1-4b80-8d72-d2123c170ba9
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 10:57:20
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 10:57:20
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;

using JCE.DataCenter.Infrastructure.CommonModel;
using JCE.DataCenter.Infrastructure.Domain.Entities;
using JCE.DataCenter.Infrastructure.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;
using JCE.DataCenter.Infrastructure.EntityFramework.DBContext;
using JCE.DataCenter.Infrastructure.EntityFramework.Extensions;
using JCE.DataCenter.Infrastructure.EntityFramework.Uow;
using JCE.DataCenter.Infrastructure.SqlBuilder;
using JCE.DataCenter.Infrastructure.SqlBuilder.Page;
using JCE.DataCenter.Infrastructure.SqlBuilder.Where;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Repositories
{
    /// <summary>
    /// 仓储基类，定义仓储模型中的数据标准操作
    /// </summary>
    public abstract partial class Repository : IRepository
    {
        #region Property(属性)
        /// <summary>
        /// 工作单元
        /// </summary>
        protected UnitOfWork UnitOfWork { get; private set; }

        /// <summary>
        /// 是否读写分离
        /// </summary>
        private static readonly bool IsReadWriteSeparation = false;

        /// <summary>
        /// 主库
        /// </summary>
        protected DbContext MasterDb;

        /// <summary>
        /// 从库
        /// </summary>
        protected DbContext SlaveDb;

        /// <summary>
        /// 数据库连接
        /// </summary>
        protected IDbConnection Connection
        {
            get { return this.UnitOfWork.Database.Connection; }
        }
        #endregion

        #region Constructor(构造函数)
        /// <summary>
        /// 初始化一个<see cref="Repository"/>类型的实例
        /// </summary>
        /// <param name="factory">数据上下文工厂</param>
        protected Repository(DbContextFactory factory)
        {
            var masterDb = new Lazy<DbContext>(factory.GetWriteDbContext);
            var slaveDb = new Lazy<DbContext>(factory.GetReadDbContext);
            MasterDb = masterDb.Value;
            SlaveDb = IsReadWriteSeparation ? slaveDb.Value : masterDb.Value;
            UnitOfWork = (UnitOfWork)MasterDb;
        }

        /// <summary>
        /// 初始化一个<see cref="Repository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = (UnitOfWork)unitOfWork;
            SlaveDb = MasterDb = (DbContext)unitOfWork;
        }
        #endregion

        #region ExecuteSqlCommand(执行sql语句增删改)
        /// <summary>
        /// 执行sql语句增删改，返回影响的行数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        public int ExecuteSqlCommand(string sql, params object[] parms)
        {
            return MasterDb.Database.ExecuteSqlCommand(sql, parms);
        }
        #endregion

        #region SqlQuery(执行sql语句查询)
        /// <summary>
        /// 执行sql语句查询，返回实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        public TEntity SqlSingle<TEntity>(string sql, params object[] parms)
        {
            return SlaveDb.Database.SqlQuery<TEntity>(sql, parms).FirstOrDefault();
        }

        /// <summary>
        /// 执行sql语句查询，返回集合
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        public List<TEntity> SqlQuery<TEntity>(string sql, params object[] parms)
        {
            return SlaveDb.Database.SqlQuery<TEntity>(sql, parms).ToList();
        }

        /// <summary>
        /// Sql分页查询
        /// </summary>
        /// <typeparam name="TEntity">返回结果</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="where">where条件</param>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="order">排序，例如：name desc,nickname desc</param>
        /// <returns></returns>
        public PagedResult<TEntity> SqlPage<TEntity>(string sql,string where, int page, int pageSize, string order) where TEntity : class, new()
        {
            string whereSql = "";
            if (!where.TrimStart().StartsWith("where"))
            {
                whereSql += " where ";
            }
            whereSql += where;

            var pageSql = PageBuilder.GeneratePagingWithRowNumberSql(sql, whereSql, page, pageSize, order);
            var countSql = PageBuilder.GenerateRecordCount(sql, whereSql);
            PagedResult<TEntity> result=new PagedResult<TEntity>();
            result.Page = page;
            result.PageSize = pageSize;
            result.Data = this.SlaveDb.Database.SqlQuery<TEntity>(pageSql).ToList();
            result.TotalCount = this.SlaveDb.Database.SqlQuery<int>(countSql).SingleOrDefault();
            return result;
        }

        /// <summary>
        /// Sql分页查询
        /// </summary>
        /// <typeparam name="TEntity">返回结果</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="where">where条件</param>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="order">排序，例如：name desc,nickname desc</param>
        /// <returns></returns>
        public PagedResult<TEntity> SqlPage<TEntity>(string sql, WhereCondition where, int page, int pageSize,
            string order) where TEntity : class, new()
        {
            string whereSql = where.BuildSql();
            return this.SqlPage<TEntity>(sql, whereSql, page, pageSize, order);
        }
        #endregion
    }    
}