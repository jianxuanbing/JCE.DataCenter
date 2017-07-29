/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：ClassFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：facd8e4f-40b5-4810-b0ec-008c6760199f
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 12:58:24
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 12:58:24
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
    /// 类格式器
    /// </summary>
    internal class ClassFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化类格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public ClassFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            Add("类名", Message.Class);
            Add("方法", Message.Method);
            return Result.ToString();
        }
    }
}
