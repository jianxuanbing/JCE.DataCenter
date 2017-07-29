/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Domain.Repositories.Pager
 * 文件名：IPagerBase
 * 版本号：v1.0.0.0
 * 唯一标识：04bac606-34b6-4ac5-92b6-d4397e06b351
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/15 13:36:45
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/15 13:36:45
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

namespace JCE.DataCenter.Infrastructure.Domain.Repositories.Pager
{
    /// <summary>
    /// 分页
    /// </summary>
    public interface IPagerBase
    {
        /// <summary>
        /// 页数，即从第几页，从1开始
        /// </summary>
        int Page { get; set; }

        /// <summary>
        /// 每页显示行数
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        int TotalCount { get; set; }
    }
}
