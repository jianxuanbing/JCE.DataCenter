/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Aop
 * 文件名：TransactionAttribute
 * 版本号：v1.0.0.0
 * 唯一标识：99b0159b-e327-4819-b35e-fb47ce6915cc
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 19:02:27
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 19:02:27
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
using System.Transactions;

namespace JCE.DataCenter.Infrastructure.Aop
{
    /// <summary>
    /// 开启事务属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method,Inherited = true)]
    public class TransactionCallHandlerAttribute:Attribute
    {
        /// <summary>
        /// 超时时间
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 事务范围
        /// </summary>
        public TransactionScopeOption ScopeOption { get; set; }

        /// <summary>
        /// 事务隔离级别
        /// </summary>
        public IsolationLevel IsolationLevel { get; set; }

        public TransactionCallHandlerAttribute()
        {
            Timeout = 60;
            ScopeOption=TransactionScopeOption.Required;
            IsolationLevel=IsolationLevel.ReadCommitted;
        }
    }
}
