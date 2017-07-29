/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.CommonModel
 * 文件名：PagedResult
 * 版本号：v1.0.0.0
 * 唯一标识：a6197af1-6938-461d-b547-d4f0c582f044
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 18:45:05
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 18:45:05
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
    /// 分页结果
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class PagedResult<TEntity> where TEntity : class,new()
    {
        /// <summary>
        /// 页索引，即从第几页，从1开始
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 结果数据
        /// </summary>
        public List<TEntity> Data { get; set; }

        /// <summary>
        /// 初始化一个<see cref="PagedResult{TEntity}"/>类型的实例
        /// </summary>
        public PagedResult()
        {
            Data=new List<TEntity>();
        }
    }
}
