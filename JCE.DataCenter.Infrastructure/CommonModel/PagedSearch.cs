/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.CommonModel
 * 文件名：PagedSearch
 * 版本号：v1.0.0.0
 * 唯一标识：e1492183-f661-4c3f-9b04-7b5b68446448
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 18:38:25
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 18:38:25
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.CommonModel
{
    /// <summary>
    /// 分页查询类
    /// </summary>
    public class PagedSearch
    {
        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 页索引，即从第几页，从1开始
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 初始化一个<see cref="PagedSearch"/>类型的实例
        /// </summary>
        public PagedSearch() : this(1, 15)
        {            
        }

        /// <summary>
        /// 初始化一个<see cref="PagedSearch"/>类型的实例
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数</param>
        public PagedSearch(int page,int pageSize)
        {
            this.PageSize = pageSize;
            this.Page = page;
        }
    }

    /// <summary>
    /// 分页查询类，带分页条件信息
    /// </summary>
    /// <typeparam name="TEntity">查询条件</typeparam>
    public class PagedSearch<TEntity> : PagedSearch where TEntity : new()
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        public TEntity Condition { get; set; }

        /// <summary>
        /// 初始化一个<see cref="PagedSearch{TEntity}"/>类型的实例
        /// </summary>
        public PagedSearch() : this(1, 15, new TEntity())
        {            
        }

        /// <summary>
        /// 初始化一个<see cref="PagedSearch{TEntity}"/>类型的实例
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <param name="condition"></param>
        public PagedSearch(int page, int pageSize,  TEntity condition) : base(page, pageSize)
        {
            this.Condition = condition;
        }
    }
}
