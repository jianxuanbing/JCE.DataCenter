/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Domain.Repositories
 * 文件名：IRepository_
 * 版本号：v1.0.0.0
 * 唯一标识：7d4205ae-bf72-4082-9b59-4cacf5fdb9fa
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 17:02:41
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 17:02:41
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JCE.DataCenter.Infrastructure.CommonModel;
using JCE.DataCenter.Infrastructure.Domain.Entities;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Infrastructure.Domain.Repositories
{
    /// <summary>
    /// 仓储，定义仓储模型中的数据操作标准
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public partial interface IRepository<TEntity, TKey> : IRepository where TEntity : class, IEntity<TEntity, TKey>
    {
        /// <summary>
        /// 获取 当前实体类型的查询数据集，数据将使用不跟踪变化的方式来查询，当数据用于展现时，推荐使用此数据集，如果用于新增，更新，删除时，请使用<see cref="TrackEntities"/>数据集
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        /// <summary>
        /// 获取 当前实体类型的查询数据集，当数据用于新增，更新，删除时，使用此数据集，如果数据用于展现，推荐使用<see cref="Entities"/>数据集
        /// </summary>
        IQueryable<TEntity> TrackEntities { get; }

        #region Insert(增)
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Insert(TEntity entity);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Insert(IEnumerable<TEntity> entities);
        #endregion

        #region Delete(删)
        /// <summary>
        /// 删除实体，根据实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Delete(TEntity entity);

        /// <summary>
        /// 删除实体，根据Lambda表达式条件
        /// </summary>
        /// <param name="predicate">条件</param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 批量删除实体，根据Lambda表达式条件
        /// </summary>
        /// <param name="predicate">条件</param>
        void BatchDelete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 删除实体，根据主键ID
        /// </summary>
        /// <param name="id">主键ID</param>
        void Delete(object id);

        ///// <summary>
        ///// 批量删除实体，根据主键ID集合
        ///// </summary>
        ///// <param name="ids">主键ID集合</param>
        //void Delete(IEnumerable<TKey> ids);

        /// <summary>
        /// 批量删除实体，根据实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Delete(IEnumerable<TEntity> entities);
        #endregion

        #region Update(改)
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update(TEntity entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="newEntity">新实体</param>
        /// <param name="oldEntity">数据库中旧的实体</param>
        void Update(TEntity newEntity, TEntity oldEntity);

        /// <summary>
        /// 更新实体，指定列修改
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="properties">要修改的 属性 名称</param>
        /// <param name="isProUpdate">true:指定列更新,false:忽略列更新</param>
        void Update(TEntity entity, List<string> properties, bool isProUpdate = true);

        /// <summary>
        /// 批量更新实体，根据Lambda表达式条件更新
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="updateExpression">更新表达式</param>
        void Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression);

        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// 批量更新实体，统一修改
        /// </summary>
        /// <param name="entity">要修改的实体对象</param>
        /// <param name="predicate">条件</param>
        /// <param name="modifiedProNames">要修改的 属性 名称</param>
        void Update(TEntity entity, Expression<Func<TEntity, bool>> predicate, params string[] modifiedProNames);

        #endregion

        #region Select(查)
        /// <summary>
        /// 获取实体，根据主键ID
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        TEntity FindById(object id);

        /// <summary>
        /// 获取实体，根据条件获取，不存在则返回Null
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// 获取实体集合，全部数据
        /// </summary>
        /// <param name="order">排序字段</param>
        /// <returns></returns>
        List<TEntity> FindAll(string order = null);

        /// <summary>
        /// 获取实体集合，条件查询数据
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="order">排序字段</param>
        /// <returns></returns>
        List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, string order = null);

        ///// <summary>
        ///// 获取实体集合，根据主键ID集合
        ///// </summary>
        ///// <param name="ids">主键ID集合</param>
        ///// <returns></returns>
        //List<TEntity> FindByIds(IEnumerable<TKey> ids);

        /// <summary>
        /// 获取未跟踪的实体查询对象
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        IQueryable<TEntity> FindAsNoTraking(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// 获取跟踪的实体查询对象
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// 获取实体，索引器查找，获取指定标识的实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        TEntity this[TKey id] { get; }

        /// <summary>
        /// 判断实体是否存在
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        bool Exists(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取实体集合数量
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="total">总记录数</param>
        /// <param name="orderBy">排序条件（一定要有）</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="desc">排序方式,true:降序,false:升序</param>
        /// <returns></returns>
        List<TEntity> Page(int page, int pageSize, out int total, Expression<Func<TEntity, TKey>> orderBy,
            Expression<Func<TEntity, bool>> predicate = null, bool desc = true);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="total">总记录数</param>
        /// <param name="order">排序条件（一定要有）</param>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        List<TEntity> Page(int page, int pageSize, out int total, string order,
            Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// 分页查询-传入查询表达式
        /// </summary>
        /// <typeparam name="TResult">查询结果</typeparam>
        /// <param name="query">查询表达式</param>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="selector">返回数据</param>
        /// <returns></returns>
        PagedResult<TResult> Page<TResult>(IQueryable<dynamic> query, int page, int pageSize,
            Func<dynamic, TResult> selector) where TResult : class, new();

        /// <summary>
        /// 查询转换
        /// </summary>
        /// <typeparam name="TDto">数据传输对象</typeparam>
        /// <param name="predicate">条件</param>
        /// <returns></returns>
        List<TDto> Select<TDto>(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Other(其他)

        /// <summary>
        /// 保存
        /// </summary>
        void Save();

        /// <summary>
        /// 清空实体
        /// </summary>
        void Clear();

        /// <summary>
        /// 清空缓存
        /// </summary>
        void ClearCache();

        /// <summary>
        /// 获取工作单元
        /// </summary>
        /// <returns></returns>
        IUnitOfWork GetUnitOfWork();

        /// <summary>
        /// 执行存储过程或自定义sql语句 --返回集合
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        List<TEntity> SqlQuery(string sql, params object[] parms);

        #endregion

    }
}
