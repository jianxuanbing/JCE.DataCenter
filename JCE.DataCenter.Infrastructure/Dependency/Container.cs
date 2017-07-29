/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Dependency
 * 文件名：Container
 * 版本号：v1.0.0.0
 * 唯一标识：5a462809-0aab-448e-9e0c-e505700618b2
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 22:20:00
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 22:20:00
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
using System.Web.Http;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;

namespace JCE.DataCenter.Infrastructure.Dependency
{
    /// <summary>
    /// Autofac对象容器
    /// </summary>
    public class Container
    {
        /// <summary>
        /// 容器
        /// </summary>
        private static IContainer _container;

        /// <summary>
        /// WebApi依赖解析器
        /// </summary>
        private static AutofacWebApiDependencyResolver _webapiResolver;

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns></returns>
        public static T Create<T>()
        {
            return _container.Resolve<T>();
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <returns></returns>
        public static object Create(Type type)
        {
            return _container.Resolve(type);
        }

        /// <summary>
        /// 为Web注册依赖
        /// </summary>
        /// <param name="assembly">项目所在的程序集</param>
        /// <param name="action">在注册模块前执行的操作</param>
        /// <param name="modules">配置模块</param>
        public static void Register(Assembly assembly, Action<ContainerBuilder> action, params IModule[] modules)
        {
            var config = GlobalConfiguration.Configuration;
            var builder = CreateBuilder(action, modules);
            builder.RegisterApiControllers(assembly);
            builder.RegisterWebApiFilterProvider(config);
            _container = builder.Build();
            _webapiResolver=new AutofacWebApiDependencyResolver(_container);
            config.DependencyResolver = _webapiResolver;
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        /// <param name="action">在注册模块前执行的操作</param>
        /// <param name="modules">配置模块</param>
        /// <returns></returns>
        public static ContainerBuilder CreateBuilder(Action<ContainerBuilder> action, params IModule[] modules)
        {
            var builder=new ContainerBuilder();
            if (action != null)
            {
                action(builder);
            }
            foreach (IModule module in modules)
            {
                builder.RegisterModule(module);
            }
            return builder;
        }
    }
}
