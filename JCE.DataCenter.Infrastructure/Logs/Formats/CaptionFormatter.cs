/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：CaptionFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：bf4c411b-703f-4133-b182-d40e86b6ce63
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 12:58:09
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 12:58:09
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
    internal class CaptionFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化标题格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public CaptionFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            Add("标题", Message.Caption);
            return Result.ToString();
        }
    }
}
