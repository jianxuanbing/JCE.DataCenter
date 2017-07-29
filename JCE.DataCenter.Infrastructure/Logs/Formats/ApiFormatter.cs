/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：ApiFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：6b1d9b37-ea59-464e-852d-b68c028acebd
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 15:05:20
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 15:05:20
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

namespace JCE.DataCenter.Infrastructure.Logs.Formats
{
    /// <summary>
    /// Api格式器
    /// </summary>
    internal class ApiFormatter:FormatterBase
    {
        /// <summary>
        /// 初始化Api格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public ApiFormatter(LogMessage message) : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <returns></returns>
        public override string Format()
        {
            Add("Area",Message.Area);
            Add("Controller",Message.Controller);
            Add("Action",Message.Action);
            Add("Type",Message.RequestType);
            return Result.ToString();
        }
    }
}
