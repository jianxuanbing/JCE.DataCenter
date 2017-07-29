/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：FormatterBase
 * 版本号：v1.0.0.0
 * 唯一标识：f94db89b-fb2c-4ff5-9bca-410eea4930d7
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 12:52:27
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 12:52:27
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
    /// 日志消息基格式器
    /// </summary>
    internal abstract class FormatterBase
    {
        /// <summary>
        /// 初始化日志消息格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        protected FormatterBase(LogMessage message)
        {
            Message = message;
            Result = new StringBuilder();
        }

        /// <summary>
        /// 日志消息
        /// </summary>
        public LogMessage Message { get; set; }

        /// <summary>
        /// 输出结果
        /// </summary>
        public StringBuilder Result { get; set; }

        /// <summary>
        /// 格式化
        /// </summary>
        public abstract string Format();

        /// <summary>
        /// 添加消息
        /// </summary>
        protected void Add(string caption, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;
            Result.AppendFormat("{0}: {1}   ", caption, value);
        }
    }
}
