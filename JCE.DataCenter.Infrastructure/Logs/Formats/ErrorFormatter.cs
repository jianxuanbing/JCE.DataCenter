/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：ErrorFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：353e26cc-4559-40db-bcda-21660cc42189
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 12:58:56
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 12:58:56
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
using JCE.Utils;

namespace JCE.DataCenter.Infrastructure.Logs.Formats
{
    /// <summary>
    /// 错误格式器
    /// </summary>
    internal class ErrorFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化错误格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public ErrorFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            AddErrorCode();
            AddError();
            return Result.ToString();
        }

        /// <summary>
        /// 添加错误码
        /// </summary>
        private void AddErrorCode()
        {
            if (string.IsNullOrWhiteSpace(Message.ErrorCode) && string.IsNullOrWhiteSpace(Message.Error) == false)
            {
                Result.AppendLine("错误:");
                return;
            }
            if (!string.IsNullOrWhiteSpace(Message.ErrorCode))
                Result.AppendFormat("错误码:{0}{1}", Message.ErrorCode, Sys.Line);
        }

        /// <summary>
        /// 添加错误消息
        /// </summary>
        private void AddError()
        {
            if (string.IsNullOrWhiteSpace(Message.Error))
                return;
            Result.Append(Message.Error);
        }
    }
}
