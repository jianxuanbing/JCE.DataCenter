/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Caching
 * 文件名：InternalCacher
 * 版本号：v1.0.0.0
 * 唯一标识：05def9c6-d86e-441f-8cde-d3d66858f14b
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 13:06:32
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 13:06:32
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
using JCE.DataCenter.Infrastructure.Dependency;
using JCE.DataCenter.Infrastructure.Logs;

namespace JCE.DataCenter.Infrastructure.Caching
{
    /// <summary>
    /// 缓存执行者
    /// </summary>
    internal sealed class InternalCacher:ICache
    {
        private readonly ICollection<ICache> _caches;

        /// <summary>
        /// 初始化一个<see cref="InternalCacher"/>类型的实例
        /// </summary>
        /// <param name="region">缓存区域名称</param>
        public InternalCacher(string region)
        {
            _caches = CacheManager.Providers.Where(m => m != null).Select(m => m.GetCache(region)).ToList();
            if (_caches.Count == 0)
            {
                throw new Exception("缓存功能尚未初始化，未找到可用的ICacheProvider实现。");
            }
        }

        public object Get(string key)
        {
            object value = null;
            foreach (var cache in _caches)
            {
                value = cache.Get(key);
                if (value != null)
                {
                    break;
                }
            }
            return value;
        }

        public T Get<T>(string key)
        {
            object value = Get(key);
            if (value == null)
            {
                return default(T);
            }
            return (T) value;
        }

        public IEnumerable<object> GetAll()
        {
            List<object> values=new List<object>();
            foreach (var cache in _caches)
            {
                values = cache.GetAll().ToList();
                if (values.Count != 0)
                {
                    break;
                }
            }
            return values;
        }


        public IEnumerable<T> GetAll<T>()
        {
            List<T> values = new List<T>();
            foreach (var cache in _caches)
            {
                values = cache.GetAll<T>().ToList();
                if (values.Count != 0)
                {
                    break;
                }
            }
            return values;
        }

        public void Set(string key, object value)
        {
            foreach (var cache in _caches)
            {
                cache.Set(key,value);
            }
        }

        public void Set(string key, object value, int time)
        {
            foreach (var cache in _caches)
            {
                cache.Set(key, value,time);
            }
        }

        public void Set(string key, object value, DateTime absoluteExpiration)
        {
            foreach (var cache in _caches)
            {
                cache.Set(key, value, absoluteExpiration);
            }
        }

        public void Set(string key, object value, TimeSpan slidingExpiration)
        {
            foreach (var cache in _caches)
            {
                cache.Set(key, value, slidingExpiration);
            }
        }

        public void Remove(string key)
        {
            foreach (var cache in _caches)
            {
                cache.Remove(key);
            }
        }

        public void Clear()
        {
            foreach (var cache in _caches)
            {
                cache.Clear();
            }
        }

        public bool Contains(string key)
        {
            var obj = Get(key);
            if (obj == null)
            {
                return false;
            }
            return true;
        }
    }
}
