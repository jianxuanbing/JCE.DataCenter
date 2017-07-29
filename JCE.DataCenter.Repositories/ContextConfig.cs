/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Repositories
 * 文件名：IocConfig
 * 版本号：v1.0.0.0
 * 唯一标识：be4f98c2-8291-40e1-88ac-5ce7315cf4cb
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/15 12:52:45
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/15 12:52:45
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
using Autofac;
using JCE.DataCenter.Infrastructure.Aop;
using JCE.DataCenter.Infrastructure.Dependency;
using JCE.DataCenter.Infrastructure.Domain.Uow;
using JCE.DataCenter.Infrastructure.Logs;
using JCE.DataCenter.Logs.Log4Net;

namespace JCE.DataCenter.Repositories
{
    /// <summary>
    /// 上下文IOC配置
    /// </summary>
    public class ContextConfig
    {
        /// <summary>
        /// 注册上下文
        /// </summary>
        /// <param name="builder">容器</param>
        /// <returns></returns>
        public static ContainerBuilder RegisterContext(ContainerBuilder builder)
        {
            builder.RegisterType<DataCenterUnitOfWork>().As<IUnitOfWork>();
            return builder;
        }
    }
}
