/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Caching
 * 文件名：RuntimeMemoryCache
 * 版本号：v1.0.0.0
 * 唯一标识：33f174b6-b912-41fd-a19f-de88bc397f1f
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 13:45:07
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 13:45:07
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using JCE.Utils.Extensions;

namespace JCE.DataCenter.Infrastructure.Caching
{
    /// <summary>
    /// 运行时内存缓存
    /// </summary>
    public class RuntimeMemoryCache: CacheBase
    {
        private readonly string _region;
        private readonly ObjectCache _cache;

        /// <summary>
        /// 获取 缓存区域名称，可作为缓存键标识，给缓存管理带来便利
        /// </summary>
        public override string Region
        {
            get { return _region; }
        }

        /// <summary>
        /// 初始化一个<see cref="RuntimeMemoryCache"/>类型的实例
        /// </summary>
        /// <param name="region"></param>
        public RuntimeMemoryCache(string region)
        {
            _region = region;
            _cache = MemoryCache.Default;
        }

        public override object Get(string key)
        {
            key.CheckNotNull("key");
            string cacheKey = GetCacheKey(key);
            object value = _cache.Get(cacheKey);
            if (value == null)
            {
                return null;
            }
            DictionaryEntry entry = (DictionaryEntry) value;
            if (!key.Equals(entry.Key))
            {
                return null;
            }
            return entry.Value;
        }

        public override T Get<T>(string key)
        {
            return (T) Get(key);
        }

        public override IEnumerable<object> GetAll()
        {
            string token = string.Concat(_region, ":");
            return
                _cache.Where(m => m.Key.StartsWith(token))
                    .Select(m => m.Value)
                    .Cast<DictionaryEntry>()
                    .Select(m => m.Value);
        }

        public override IEnumerable<T> GetAll<T>()
        {
            return GetAll().Cast<T>();
        }

        public override void Set(string key, object value)
        {
            key.CheckNotNull("key");
            value.CheckNotNull("value");
            string cacheKey = GetCacheKey(key);
            DictionaryEntry entry=new DictionaryEntry(key,value);
            CacheItemPolicy policy=new CacheItemPolicy();
            _cache.Set(cacheKey,entry,policy);
        }

        public override void Set(string key, object value, int time)
        {
            Set(key, value, DateTime.Now.AddSeconds(time));
        }

        public override void Set(string key, object value, DateTime absoluteExpiration)
        {
            key.CheckNotNull("key");
            value.CheckNotNull("value");
            string cacheKey = GetCacheKey(key);
            DictionaryEntry entry = new DictionaryEntry(key, value);
            CacheItemPolicy policy = new CacheItemPolicy() { AbsoluteExpiration = absoluteExpiration };
            _cache.Set(cacheKey, entry, policy);
        }

        public override void Set(string key, object value, TimeSpan slidingExpiration)
        {
            key.CheckNotNull("key");
            value.CheckNotNull("value");
            string cacheKey = GetCacheKey(key);
            DictionaryEntry entry = new DictionaryEntry(key, value);
            CacheItemPolicy policy = new CacheItemPolicy() { SlidingExpiration = slidingExpiration };
            _cache.Set(cacheKey, entry, policy);
        }

        public override void Remove(string key)
        {
            key.CheckNotNull("key");
            string cacheKey = GetCacheKey(key);
            _cache.Remove(cacheKey);
        }

        public override void Clear()
        {
            string token = _region + ":";
            List<string> cacheKeys = _cache.Where(m => m.Key.StartsWith(token)).Select(m => m.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                _cache.Remove(cacheKey);
            }
        }


        public override bool Contains(string key)
        {
            string cacheKey = GetCacheKey(key);
            return _cache.Contains(cacheKey);
        }

        /// <summary>
        /// 获取缓存键
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        private string GetCacheKey(string key)
        {
            return string.Concat(_region, ":", key, "@", key.GetHashCode());
        }
    }
}
