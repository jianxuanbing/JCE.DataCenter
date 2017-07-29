/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：StackTraceFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：e8233ae4-69aa-4e5b-bec3-3b72c69fa276
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 13:00:57
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 13:00:57
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
    /// 堆栈跟踪格式器
    /// </summary>
    internal class StackTraceFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化堆栈跟踪格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public StackTraceFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            if (string.IsNullOrWhiteSpace(Message.StackTrace))
                return string.Empty;
            Result.AppendLine("堆栈跟踪:");
            Result.Append(Message.StackTrace);
            return Result.ToString();
        }
    }
}
