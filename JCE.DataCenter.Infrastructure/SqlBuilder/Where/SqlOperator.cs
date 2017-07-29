/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.SqlBuilder.Where
 * 文件名：SqlOperator
 * 版本号：v1.0.0.0
 * 唯一标识：6cbf86a6-b246-469c-9cd7-bf23ac4c1f64
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 9:03:37
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 9:03:37
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

namespace JCE.DataCenter.Infrastructure.SqlBuilder.Where
{
    /// <summary>
    /// Sql操作符
    /// </summary>
    public enum SqlOperator
    {
        /// <summary>
        /// 等于
        /// </summary>        
        Equal =0,
        /// <summary>
        /// 不等于
        /// </summary>
        NotEqual=1,
        /// <summary>
        /// 大于等于
        /// </summary>
        GreaterThanEqual=2,
        /// <summary>
        /// 小于等于
        /// </summary>
        LessThanEqual=3,
        /// <summary>
        /// 小于
        /// </summary>
        LessThan=4,
        /// <summary>
        /// 大于
        /// </summary>
        GreaterThan=5,
        /// <summary>
        /// 全模糊
        /// </summary>
        Like=6,
        /// <summary>
        /// 左模糊
        /// </summary>
        LikeLeft=7,
        /// <summary>
        /// 右模糊
        /// </summary>
        LikeRight=8,
        /// <summary>
        /// In
        /// </summary>
        In=9,
        /// <summary>
        /// 范围
        /// </summary>
        Between=10
    }
}
