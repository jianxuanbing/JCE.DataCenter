/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Services
 * 文件名：GlobalInitialize
 * 版本号：v1.0.0.0
 * 唯一标识：8b7fd498-a510-49d9-9be8-32c99e3b4175
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 16:12:25
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 16:12:25
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
using JCE.DataCenter.Domain.Config;
using JCE.DataCenter.Infrastructure.Caching;
using JCE.DataCenter.Infrastructure.Dependency;
using JCE.DataCenter.Infrastructure.Domain.Uow;
using JCE.DataCenter.Infrastructure.Logs;
using JCE.DataCenter.Logs.Log4Net;
using JCE.DataCenter.Repositories;

namespace JCE.DataCenter.Services
{
    /// <summary>
    /// 全局初始化
    /// </summary>
    public class GlobalInitialize
    {
        private static readonly ILog logger = Log.GetLog(typeof(GlobalInitialize));

        /// <summary>
        /// 初始化Ioc
        /// </summary>
        public static void InitIoc(Assembly assembly)
        {
            Ioc.Register(assembly, new IocConfig());
            logger.Debug("依赖注入初始化完成");
        }

        /// <summary>
        /// 注册全局初始化信息
        /// </summary>
        public static void Register()
        {
            logger.Debug("网站启动");            
            ConfigContainer.Register();
            logger.Debug("配置初始化完成");
            logger.Debug("初始化数据库上下文完成");
            InitCache();
            logger.Debug("初始化缓存完成");
        }

        /// <summary>
        /// 初始化缓存驱动
        /// </summary>
        private static void InitCache()
        {
            ICacheProvider provider=new RuntimeMemoryCacheProvider();
            CacheManager.SetProvider(provider,CacheLevel.First);
        }
    }
}
