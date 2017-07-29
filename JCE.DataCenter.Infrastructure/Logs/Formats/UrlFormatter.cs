/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：UrlFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：e2bba6e1-4b20-4621-a79e-442ffbb3f405
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 13:01:30
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 13:01:30
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
    /// Url格式器
    /// </summary>
    internal class UrlFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化Url格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public UrlFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            AddUrl();
            return Result.ToString();
        }

        /// <summary>
        /// 添加Url
        /// </summary>
        private void AddUrl()
        {
            if (string.IsNullOrWhiteSpace(Message.Url))
                return;
            Result.AppendFormat("Url: {0}", Message.Url);
        }
    }
}
