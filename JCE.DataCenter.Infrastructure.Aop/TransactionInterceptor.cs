/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Aop
 * 文件名：TransactionInterceptor
 * 版本号：v1.0.0.0
 * 唯一标识：f280fa7d-0e93-42ea-a2d5-034680339eed
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 21:58:52
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 21:58:52
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Castle.DynamicProxy;
using JCE.DataCenter.Infrastructure.Exceptions;
using JCE.DataCenter.Infrastructure.Logs;
using JCE.DataCenter.Logs.Log4Net;

namespace JCE.DataCenter.Infrastructure.Aop
{
    /// <summary>
    /// 事务 拦截器
    /// </summary>
    public class TransactionInterceptor:IInterceptor
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        private static readonly ILog Logger = Log.GetLog(typeof(TransactionInterceptor));

        // 是否开发模式
        private bool isDev = false;
        public void Intercept(IInvocation invocation)
        {
            if (!isDev)
            {
                MethodInfo methodInfo = invocation.MethodInvocationTarget;
                if (methodInfo == null)
                {
                    methodInfo = invocation.Method;
                }
                
                                
                TransactionCallHandlerAttribute transaction =
                    methodInfo.GetCustomAttributes<TransactionCallHandlerAttribute>(true).FirstOrDefault();
                if (transaction != null)
                {
                    TransactionOptions transactionOptions = new TransactionOptions();
                    //设置事务隔离级别
                    transactionOptions.IsolationLevel = transaction.IsolationLevel;
                    //设置事务超时时间为60秒
                    transactionOptions.Timeout = new TimeSpan(0, 0, transaction.Timeout);
                    using (TransactionScope scope = new TransactionScope(transaction.ScopeOption, transactionOptions))
                    {
                        try
                        {
                            //实现事务性工作
                            invocation.Proceed();
                            scope.Complete();
                        }
                        catch (Exception ex)
                        {
                            if (!(ex is BusinessException))
                            {
                                Logger.Caption("事务异常");
                                Logger.Exception(ex);
                                Logger.Error();
                            }                            
                            throw ex;
                        }
                    }
                }
                else
                {
                    // 没有事务时直接执行方法
                    invocation.Proceed();
                }
            }
            else
            {
                // 开发模式直接跳过拦截
                invocation.Proceed();
            }
        }
    }
}
