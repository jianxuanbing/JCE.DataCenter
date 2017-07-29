/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Services
 * 文件名：IocConfig
 * 版本号：v1.0.0.0
 * 唯一标识：613029e3-3b01-4212-8408-c74e45744174
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/15 13:12:04
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/15 13:12:04
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
using Autofac.Extras.DynamicProxy;
using JCE.DataCenter.Infrastructure.Aop;
using JCE.DataCenter.Infrastructure.Dependency;
using JCE.DataCenter.Infrastructure.Domain.Uow;
using JCE.DataCenter.Infrastructure.Logs;
using JCE.DataCenter.Logs.Log4Net;
using JCE.DataCenter.Repositories;

namespace JCE.DataCenter.Services
{
    /// <summary>
    /// 应用程序IOC配置
    /// </summary>
    public class IocConfig : ConfigBase
    {
        // 重写加载配置
        protected override void Load(ContainerBuilder builder)
        {
            //base.Load(builder);                     
            builder=ContextConfig.RegisterContext(builder);
            builder.RegisterType<Log>().As<ILog>();
            var assembly = this.GetType().GetTypeInfo().Assembly;

            builder.RegisterType<CachingInterceptor>();
            builder.RegisterType<TransactionInterceptor>();
            builder.RegisterAssemblyTypes(assembly)
                .Where(type => typeof(IDependency).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(TransactionInterceptor))
                .InterceptedBy(typeof(CachingInterceptor));
        }
    }
}
