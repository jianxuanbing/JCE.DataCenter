/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.SqlBuilder
 * 文件名：OrderType
 * 版本号：v1.0.0.0
 * 唯一标识：2909e0b8-c3e6-4a9b-864f-7b1b316412c1
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 9:08:32
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 9:08:32
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.SqlBuilder
{
    /// <summary>
    /// 排序类型
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// 降序
        /// </summary>
        [Description("降序")]
        Desc=1,
        /// <summary>
        /// 升序
        /// </summary>
        [Description("升序")]
        Asc=2
    }
}
