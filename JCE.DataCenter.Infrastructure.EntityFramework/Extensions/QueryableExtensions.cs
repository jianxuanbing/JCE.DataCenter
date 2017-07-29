/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Extensions
 * 文件名：QueryableExtensions
 * 版本号：v1.0.0.0
 * 唯一标识：ba021234-b969-40f1-a1db-133262b8ebc0
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 15:58:08
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 15:58:08
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JCE.DataCenter.Infrastructure.CommonModel;
using JCE.DataCenter.Infrastructure.Domain.Repositories.Pager;
using JCE.DataCenter.Infrastructure.EntityFramework.Method;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Extensions
{
    /// <summary>
    /// 查询扩展
    /// </summary>
    public static class QueryableExtensions
    {

        /// <summary>
        /// And 条件语句
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="first">条件1</param>
        /// <param name="second">条件2</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first,
            Expression<Func<T, bool>> second)
        {
            return ParameterRebinder.Compose(first, second, Expression.And);
        }

        /// <summary>
        /// Or 条件语句
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="first">条件1</param>
        /// <param name="second">条件2</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first,
            Expression<Func<T, bool>> second)
        {
            return ParameterRebinder.Compose(first, second, Expression.Or);
        }

        /// <summary>
        /// Where If 条件语句
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="condition">判断条件</param>
        /// <param name="func">条件表达式</param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, Expression<Func<T, bool>> func)
        {
            return condition ? source.Where(func) : source;
        }

        /// <summary>
        /// Where If 条件语句
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="condition">判断条件</param>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition,
            Expression<Func<T, int, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// Where If 条件语句
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="condition">判断条件</param>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// Where If 条件语句
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="source">数据源</param>
        /// <param name="condition">判断条件</param>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, int, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <param name="query">查询条件</param>
        /// <param name="skipCount">跳过行数</param>
        /// <param name="maxResultCount">最大记录数</param>
        /// <returns></returns>
        public static IQueryable<TEntity> PageBy<TEntity>(this IQueryable<TEntity> query, int skipCount,
            int maxResultCount)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            return query.Skip(skipCount).Take(maxResultCount);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <param name="query">查询条件</param>
        /// <param name="pager">分页组件</param>
        /// <returns></returns>
        public static IQueryable<TEntity> PageBy<TEntity>(this IQueryable<TEntity> query, IPager pager)
        {
            return query.PageBy(pager.GetSkipCount(), pager.GetTakeCount());
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <param name="query">查询条件</param>
        /// <param name="order">排序，例如：username desc,qty desc</param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, string order,
            params object[] values)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            return DynamicQueryable.OrderBy(query, order, values);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="query">查询条件</param>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        public static PagedResult<TEntity> Page<TEntity>(IQueryable<TEntity> query, int page, int pageSize)
            where TEntity : class, new()
        {
            int count = query.Count();
            IPager pager = new Pager(page, pageSize, count);
            PagedResult<TEntity> result = new PagedResult<TEntity>();
            result.Page = pager.Page;
            result.PageSize = pager.PageSize;
            result.TotalCount = pager.TotalCount;
            var temp = query.PageBy(pager).ToList();
            result.Data.AddRange(temp);
            return result;
        }

        //public static IQueryable<TEntity> Select<TEntity>(this IQueryable query)
        //{
        //    if (query == null)
        //    {
        //        throw new ArgumentNullException(nameof(query));
        //    }
        //    return query.ProjectTo<TEntity>();
        //}

        #region 动态执行Sql语句扩展
        /// <summary>
        /// 执行sql命令
        /// </summary>
        /// <example>ExecuteSqlCommandEx("delete from [Table] where ID=@0", Guid.Empty)</example>
        /// <param name="database">数据库对象</param>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数值</param>
        /// <returns></returns>
        public static int ExecuteSqlCommandEx(this Database database, string sql, params object[] values)
        {
            var param = QueryableExtensions.MakeSqlParameter(sql, values);
            return database.ExecuteSqlCommand(sql, param);
        }

        /// <summary>
        /// 执行sql查询
        /// </summary>
        /// <example>SqlQueryEx("select * from [Table] where name=@0 and password=@1", "abc", "123456")</example>
        /// <typeparam name="TElement">实体类型</typeparam>
        /// <param name="database">数据库对象</param>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数值</param>
        /// <returns></returns>
        public static IEnumerable<TElement> SqlQueryEx<TElement>(this Database database, string sql,
            params object[] values)
        {
            var param = QueryableExtensions.MakeSqlParameter(sql, values);
            return database.SqlQuery<TElement>(sql, param);
        }

        /// <summary>
        /// 根据Sql语句和参数的值动态生成SqlParameter
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数值</param>
        /// <returns></returns>
        private static SqlParameter[] MakeSqlParameter(string sql, object[] values)
        {
            var matches = Regex.Matches(sql, @"@\w+");
            List<string> paramNameList = new List<string>();
            foreach (Match match in matches)
            {
                if (paramNameList.Contains(match.Value) == false)
                {
                    paramNameList.Add(match.Value);
                }
            }

            if (values.Length != paramNameList.Count)
            {
                throw new ArgumentException("values的元素数目和sql语句不匹配");
            }

            int i = 0;
            var parameters = new SqlParameter[values.Length];
            foreach (string pName in paramNameList)
            {
                parameters[i] = new SqlParameter(pName, values[i]);
                i++;
            }
            return parameters;
        }
        #endregion
    }
}
