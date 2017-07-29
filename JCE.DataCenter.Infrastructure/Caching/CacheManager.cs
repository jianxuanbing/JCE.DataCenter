/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Caching
 * 文件名：CacheManager
 * 版本号：v1.0.0.0
 * 唯一标识：92437322-dbf5-4553-b34a-20be28ad0077
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 13:13:20
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 13:13:20
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JCE.Utils.Extensions;

namespace JCE.DataCenter.Infrastructure.Caching
{
    /// <summary>
    /// 缓存操作管理器
    /// </summary>
    public static class CacheManager
    {
        /// <summary>
        /// 缓存器字典
        /// </summary>
        private static readonly ConcurrentDictionary<string, ICache> Caches;

        /// <summary>
        /// 二级缓存
        /// </summary>
        internal static readonly ICacheProvider[] Providers=new ICacheProvider[2];

        //静态构造器
        static CacheManager()
        {
            Caches=new ConcurrentDictionary<string, ICache>();
        }

        /// <summary>
        /// 设置缓存提供者
        /// </summary>
        /// <param name="provider">缓存提供者</param>
        /// <param name="level">缓存级别</param>
        public static void SetProvider(ICacheProvider provider, CacheLevel level)
        {
            provider.CheckNotNull("provider");
            switch (level)
            {
                case CacheLevel.First:
                    Providers[0] = provider;
                    break;
                case CacheLevel.Second:
                    Providers[1] = provider;
                    break;
            }
        }

        /// <summary>
        /// 移除指定级别的缓存提供者
        /// </summary>
        /// <param name="level">缓存级别</param>
        public static void RemoveProvider(CacheLevel level)
        {
            switch (level)
            {
                case CacheLevel.First:
                    Providers[0] = null;
                    break;
                case CacheLevel.Second:
                    Providers[1] = null;
                    break;
            }
        }

        /// <summary>
        /// 获取指定区域的缓存执行者实例
        /// </summary>
        /// <param name="region">缓存区域名称</param>
        /// <returns></returns>
        public static ICache GetCacher(string region)
        {
            region.CheckNotNullOrEmpty("region");
            ICache cache;
            if (Caches.TryGetValue(region, out cache))
            {
                return cache;
            }
            cache=new InternalCacher(region);
            Caches[region] = cache;
            return cache;
        }

        /// <summary>
        /// 获取指定类型的缓存执行者实例
        /// </summary>
        /// <param name="type">类型实例</param>
        /// <returns></returns>
        public static ICache GetCacher(Type type)
        {
            type.CheckNotNull("type");
            return GetCacher(type.FullName);
        }

        /// <summary>
        /// 获取指定类型的缓存执行者实力
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public static ICache GetCacher<T>()
        {
            return GetCacher(typeof(T));
        }
    }
}
