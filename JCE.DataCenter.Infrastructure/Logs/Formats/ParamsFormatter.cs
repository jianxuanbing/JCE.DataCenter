/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：ParamsFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：aaafd3f5-fee0-4caa-8210-8028c2ab443b
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 13:00:05
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 13:00:05
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
    /// 请求参数格式器
    /// </summary>
    internal class ParamsFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化类格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public ParamsFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            if (string.IsNullOrWhiteSpace(Message.Params))
                return string.Empty;
            Result.AppendLine("请求参数:");
            Result.Append(Message.Params);
            return Result.ToString();
        }
    }
}
