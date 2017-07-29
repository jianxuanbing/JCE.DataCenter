/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：BusinessFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：6fc46754-f38e-46e4-9b24-de5387225080
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 12:57:52
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 12:57:52
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
    /// 业务格式器
    /// </summary>
    internal class BusinessFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化业务格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public BusinessFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            Add("业务编号", Message.BusinessId);
            Add("应用程序", Message.Application);
            Add("租户", Message.Tenant);
            Add("分类", Message.Category);
            return Result.ToString();
        }
    }
}
