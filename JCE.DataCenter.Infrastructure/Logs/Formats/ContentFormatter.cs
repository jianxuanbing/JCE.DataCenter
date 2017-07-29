/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：ContentFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：78e2a066-cfe8-4402-83d4-d04414e2e4f6
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 12:58:39
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 12:58:39
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
    /// 内容格式器
    /// </summary>
    internal class ContentFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化内容格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public ContentFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            if (string.IsNullOrWhiteSpace(Message.Content))
                return string.Empty;
            Result.AppendLine("内容:");
            Result.Append(Message.Content);
            return Result.ToString();
        }
    }
}
