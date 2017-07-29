/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：SqlFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：c21a5698-78fe-4417-a9d0-9a920de87796
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 13:00:20
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 13:00:20
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
    /// Sql格式器
    /// </summary>
    internal class SqlFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化Sql格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public SqlFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            if (string.IsNullOrWhiteSpace(Message.Sql))
                return string.Empty;
            Result.AppendLine("Sql语句:");
            Result.Append(Message.Sql);
            return Result.ToString();
        }
    }
}
