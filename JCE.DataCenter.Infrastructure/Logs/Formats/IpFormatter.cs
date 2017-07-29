/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：IpFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：05835e3b-7441-429d-b449-79eade70ea76
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 12:59:22
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 12:59:22
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
    /// Ip格式器
    /// </summary>
    internal class IpFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化Ip格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public IpFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            Add("IP", Message.IP);
            Add("主机", Message.Host);
            Add("线程号", Message.ThreadId);
            Add("浏览器", Message.Browser);
            return Result.ToString();
        }
    }
}
