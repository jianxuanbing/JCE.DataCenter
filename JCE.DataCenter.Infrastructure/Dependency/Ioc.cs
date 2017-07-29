/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Dependency
 * 文件名：Ioc
 * 版本号：v1.0.0.0
 * 唯一标识：2f574949-dd78-49e8-8911-d11a6e7eb02d
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 22:16:54
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 22:16:54
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Compilation;
using Autofac;
using Autofac.Core;

namespace JCE.DataCenter.Infrastructure.Dependency
{
    /// <summary>
    /// 容器
    /// </summary>
    public static class Ioc
    {
        /// <summary>
        /// 需要跳过的程序集列表
        /// </summary>
        private const string AssemblySkipLoadingPattern = "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|^NSubstitute|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Telerik|^Iesi|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease";

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <returns></returns>
        public static T Create<T>()
        {
            return Container.Create<T>();
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="type">实例类型</param>
        /// <returns></returns>
        public static object Create(Type type)
        {
            return Container.Create(type);
        }

        /// <summary>
        /// 为Web项目注册依赖
        /// </summary>
        /// <param name="assembly">项目所在程序集</param>
        /// <param name="modules">依赖配置</param>
        public static void Register(Assembly assembly, params IModule[] modules)
        {
            Register(assembly,true,modules);
        }

        /// <summary>
        /// 为Web项目注册依赖
        /// </summary>
        /// <param name="assembly">项目所在程序集</param>
        /// <param name="autoRegister">是否自动注册</param>
        /// <param name="modules">依赖配置</param>
        public static void Register(Assembly assembly, bool autoRegister, params IModule[] modules)
        {
            if (!autoRegister)
            {
                Container.Register(assembly,null,modules);
                return;
            }
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            Container.Register(assembly, builder => RegisterTypes(assemblies, builder), modules);
        }

        /// <summary>
        /// 注册程序集列表中所有实现了IDependency的类型
        /// </summary>
        /// <param name="assemblies">程序集</param>
        /// <param name="builder">容器构建器</param>
        private static void RegisterTypes(IEnumerable<Assembly> assemblies, ContainerBuilder builder)
        {
            var typeBase = typeof(IDependency);
            builder.RegisterAssemblyTypes(FilterSystemAssembly(assemblies))
                .Where(t => typeBase.IsAssignableFrom(t) && t != typeBase && !t.IsAbstract)
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();
        }

        /// <summary>
        /// 过滤系统程序集
        /// </summary>
        /// <param name="assemblies">程序集</param>
        /// <returns></returns>
        private static Assembly[] FilterSystemAssembly(IEnumerable<Assembly> assemblies)
        {
            return
                assemblies.Where(
                    assembly =>
                        !Regex.IsMatch(assembly.FullName, AssemblySkipLoadingPattern,
                            RegexOptions.IgnoreCase | RegexOptions.Compiled)).ToArray();
        }
    }
}
