/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：TitleFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：a8470496-3fe9-429a-bf16-b78b4cce05a1
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 13:01:13
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 13:01:13
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
    /// 标题格式器
    /// </summary>
    internal class TitleFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化标题格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public TitleFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            AddLevel();
            AddTraceId();
            AddTime();
            AddTotalSeconds();
            return Result.ToString();
        }

        /// <summary>
        /// 添加日志级别
        /// </summary>
        private void AddLevel()
        {
            Result.AppendFormat("{0}:{1} >> ", Message.Level, Message.LogName);
        }

        /// <summary>
        /// 添加跟踪号
        /// </summary>
        private void AddTraceId()
        {
            Result.AppendFormat("跟踪号: {0}   ", Message.TraceId);
        }

        /// <summary>
        /// 添加操作时间
        /// </summary>
        private void AddTime()
        {
            Result.AppendFormat("操作时间: {0}   ", Message.OperationTime);
        }

        /// <summary>
        /// 添加已执行时间
        /// </summary>
        private void AddTotalSeconds()
        {
            if (string.IsNullOrWhiteSpace(Message.Duration))
                return;
            Result.AppendFormat("已执行: {0} 秒", Message.Duration);
        }
    }
}
