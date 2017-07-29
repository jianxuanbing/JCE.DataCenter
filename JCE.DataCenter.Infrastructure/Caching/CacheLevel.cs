/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Caching
 * 文件名：CacheLevel
 * 版本号：v1.0.0.0
 * 唯一标识：7ff782bc-fb47-4920-84a4-a30d8d197673
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 13:09:34
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 13:09:34
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

namespace JCE.DataCenter.Infrastructure.Caching
{
    /// <summary>
    /// 缓存级别
    /// </summary>
    public enum CacheLevel
    {
        /// <summary>
        /// 一级缓存
        /// </summary>
        First,
        /// <summary>
        /// 二级缓存
        /// </summary>
        Second
    }
}
