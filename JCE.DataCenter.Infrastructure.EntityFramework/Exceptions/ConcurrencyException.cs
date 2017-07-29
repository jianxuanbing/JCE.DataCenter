/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Exceptions
 * 文件名：ConcurrencyException
 * 版本号：v1.0.0.0
 * 唯一标识：2cb2d45c-8a02-463d-9c7e-ba71490a7fb2
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 14:18:08
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 14:18:08
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
using JCE.Utils.Logging;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Exceptions
{
    /// <summary>
    /// 并发异常
    /// </summary>
    public class ConcurrencyException : Exception
    {
        /// <summary>
        /// 初始化一个<see cref="ConcurrencyException"/>类型的实例
        /// </summary>
        public ConcurrencyException() : this("")
        {
        }

        /// <summary>
        /// 初始化一个<see cref="ConcurrencyException"/>类型的实例
        /// </summary>
        /// <param name="message">错误消息</param>
        public ConcurrencyException(string message) : this(message, null)
        {
        }

        /// <summary>
        /// 初始化一个<see cref="ConcurrencyException"/>类型的实例
        /// </summary>
        /// <param name="exception">异常</param>
        public ConcurrencyException(Exception exception)
            : this("", exception)
        {
        }

        /// <summary>
        /// 初始化一个<see cref="ConcurrencyException"/>类型的实例
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="exception">异常</param>
        public ConcurrencyException(string message, Exception exception)
            : base(string.Format("并发更新异常:当前操作的数据已被其他人修改，请刷新后重试{0}{1}", Sys.Line, message), exception)
        {
        }

    }
}
