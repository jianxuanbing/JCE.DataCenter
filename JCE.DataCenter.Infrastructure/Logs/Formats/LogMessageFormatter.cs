/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：LogMessageFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：85baac83-9811-492b-b373-42f419046757
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 13:02:09
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 13:02:09
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
    /// 日志消息格式器
    /// </summary>
    internal class LogMessageFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化日志消息格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public LogMessageFormatter(LogMessage message)
            : base(message)
        {
            Line = 1;
        }

        /// <summary>
        /// 行号
        /// </summary>
        private int Line { get; set; }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            Add(new TitleFormatter(Message));
            Add(new UrlFormatter(Message));
            Add(new ApiFormatter(Message));
            Add(new BusinessFormatter(Message));
            Add(new ClassFormatter(Message));
            Add(new IpFormatter(Message));
            Add(new UserFormatter(Message));
            Add(new CaptionFormatter(Message));
            Add(new ParamsFormatter(Message));
            Add(new ContentFormatter(Message));
            Add(new SqlFormatter(Message));
            Add(new SqlParamsFormatter(Message));
            Add(new ErrorFormatter(Message));
            Add(new StackTraceFormatter(Message));
            Finish();
            return Result.ToString();
        }

        /// <summary>
        /// 添加消息
        /// </summary>
        private void Add(FormatterBase formatter)
        {
            string result = formatter.Format();
            if (string.IsNullOrWhiteSpace(result))
                return;
            Result.AppendFormat("{0}. {1}{2}", Line++, result, Sys.Line);
        }

        /// <summary>
        /// 结束
        /// </summary>
        private void Finish()
        {
            for (int i = 0; i < 125; i++)
                Result.Append("-");
            Result.AppendLine();
        }
    }
}
