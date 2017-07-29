/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Domain.Repositories.Pager
 * 文件名：IPager
 * 版本号：v1.0.0.0
 * 唯一标识：378a338e-a187-421d-9f15-2d5ade3da40b
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/15 13:36:55
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/15 13:36:55
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
    /// 分页组件
    /// </summary>
    public interface IPager:IPagerBase
    {
        /// <summary>
        /// 获取总页数
        /// </summary>
        /// <returns></returns>
        int GetPageCount();

        /// <summary>
        /// 获取跳过的行数
        /// </summary>
        /// <returns></returns>
        int GetSkipCount();

        /// <summary>
        /// 获取需要的行数
        /// </summary>
        /// <returns></returns>
        int GetTakeCount();

        /// <summary>
        /// 排序条件
        /// </summary>
        string Order { get; set; }

        /// <summary>
        /// 获取起始行数
        /// </summary>
        int GetStartNumber();

        /// <summary>
        /// 获取结束行数
        /// </summary>
        int GetEndNumber();

        /// <summary>
        /// 搜索关键字
        /// </summary>
        string Keyword { get; set; }
    }
}
