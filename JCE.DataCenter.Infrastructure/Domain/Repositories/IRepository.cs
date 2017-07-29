/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Data.Repositories
 * 文件名：IRepository
 * 版本号：v1.0.0.0
 * 唯一标识：4e82fc8a-fc20-4928-b76f-d1d82d76ebd6
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 9:26:45
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 9:26:45
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using JCE.DataCenter.Infrastructure.CommonModel;
using JCE.DataCenter.Infrastructure.Data;
using JCE.DataCenter.Infrastructure.Dependency;
using JCE.DataCenter.Infrastructure.Domain.Entities;
using JCE.DataCenter.Infrastructure.Domain.Uow;
using JCE.DataCenter.Infrastructure.SqlBuilder;
using JCE.DataCenter.Infrastructure.SqlBuilder.Where;

namespace JCE.DataCenter.Infrastructure.Domain.Repositories
{
    /// <summary>
    /// 仓储，定义仓储模型中的数据标准操作
    /// </summary>
    public partial interface IRepository:IDependency
    {
        /// <summary>
        /// 执行sql语句或存储过程的增删改 返回影响的行数
        /// </summary>
        /// <param name="sql">sql语句或存储过程</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        int ExecuteSqlCommand(string sql, params object[] parms);

        /// <summary>
        /// 执行sql语句查询，返回实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        TEntity SqlSingle<TEntity>(string sql, params object[] parms);

        /// <summary>
        /// 执行sql语句或存储过程的查询 返回集合
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="sql">sql语句或存储过程</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        List<TEntity> SqlQuery<TEntity>(string sql, params object[] parms);

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
        PagedResult<TEntity> SqlPage<TEntity>(string sql, string where, int page, int pageSize, string order)
            where TEntity : class, new();

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
        PagedResult<TEntity> SqlPage<TEntity>(string sql, WhereCondition where, int page, int pageSize,
            string order) where TEntity : class, new();
    }    
}
