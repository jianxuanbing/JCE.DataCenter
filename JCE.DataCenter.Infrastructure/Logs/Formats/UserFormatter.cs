/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs.Formats
 * 文件名：UserFormatter
 * 版本号：v1.0.0.0
 * 唯一标识：27c030c6-584d-4fa9-8df4-c5dbd848c363
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 13:01:48
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 13:01:48
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
    /// 用户格式器
    /// </summary>
    internal class UserFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化用户格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public UserFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            Add("操作人编号", Message.UserId);
            Add("操作人姓名", Message.Operator);
            Add("角色", Message.Role);
            return Result.ToString();
        }
    }
}
