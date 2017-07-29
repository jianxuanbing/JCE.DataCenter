/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Logging
 * 文件名：LoggingLevel
 * 版本号：v1.0.0.0
 * 唯一标识：6379b62c-99d1-43b2-82da-ec9bb33d5a30
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/23 18:36:10
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/23 18:36:10
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

namespace JCE.DataCenter.Infrastructure.WebApi.Logging
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum LoggingLevel
    {
        /// <summary>
        /// 调试
        /// </summary>
        [Description("调试")]
        Debug,
        /// <summary>
        /// 跟踪
        /// </summary>
        [Description("跟踪")]
        Trace,
        /// <summary>
        /// 信息
        /// </summary>
        [Description("信息")]
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        [Description("警告")]
        Warn,
        /// <summary>
        /// 错误
        /// </summary>
        [Description("错误")]
        Error,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fault
    }
}
