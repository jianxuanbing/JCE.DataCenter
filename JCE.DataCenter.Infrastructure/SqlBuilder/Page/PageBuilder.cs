/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.SqlBuilder
 * 文件名：PageQuery
 * 版本号：v1.0.0.0
 * 唯一标识：89f837fe-03b4-4c2e-b6b0-49de5e58c852
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 10:53:28
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 10:53:28
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/

namespace JCE.DataCenter.Infrastructure.SqlBuilder.Page
{
    /// <summary>
    /// 分页生成器
    /// </summary>
    public class PageBuilder
    {
        /// <summary>
        /// 生成查询总记录数Sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="where">where条件</param>
        /// <returns>总记录数Sql</returns>
        public static string GenerateRecordCount(string sql,string where)
        {
            return string.Format("SELECT COUNT(1) FROM ({0} {1}) CountTable ", sql, where);
        }

        /// <summary>
        /// 获取分页查询sql语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="where">查询条件</param>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="order">排序方式</param>
        /// <returns></returns>
        public static string GeneratePagingWithRowNumberSql(string sql,string where, int page, int pageSize, string order)
        {
            page = page < 1 ? 1 : page;
            int pageStart = pageSize*(page - 1) + 1;
            int pageEnd = pageSize*page + 1;
            string pageSql =
                string.Format(
                    "select * from (select (ROW_NUMBER() over(order by {1})) as ROWNUMBER, {0}) as tp where ROWNUMBER >= {2} AND ROWNUMBER<{3}",
                    FetchPageBody(sql) + where, order, pageStart, pageEnd);
            return pageSql;
        }

        /// <summary>
        /// 从sql语句中获取分页语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        private static string FetchPageBody(string sql)
        {
            string body = sql.Substring(6, sql.Length - 6);
            return body;
        }
    }
}
