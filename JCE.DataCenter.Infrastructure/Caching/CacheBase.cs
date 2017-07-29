/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Caching
 * 文件名：CacheBase
 * 版本号：v1.0.0.0
 * 唯一标识：77e279e0-a248-43be-b1a4-0180ca82312b
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 13:06:44
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 13:06:44
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

namespace JCE.DataCenter.Infrastructure.Caching
{
    /// <summary>
    /// 缓存基类
    /// </summary>
    public abstract class CacheBase:ICache
    {
        /// <summary>
        /// 获取 缓存区域名称，可作为缓存键标识，给缓存管理带来便利
        /// </summary>
        public abstract string Region { get; }

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public abstract object Get(string key);

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        public abstract T Get<T>(string key);

        /// <summary>
        /// 获取当前缓存对象中的所有数据
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<object> GetAll();

        /// <summary>
        /// 获取当前缓存对象中的所有数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns></returns>
        public abstract IEnumerable<T> GetAll<T>();

        /// <summary>
        /// 设置缓存对象，使用默认配置
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存数据</param>
        public abstract void Set(string key, object value);

        /// <summary>
        /// 设置缓存对象，缓存时间单位：秒
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存对象</param>
        /// <param name="time">缓存过期时间，单位：秒</param>
        public abstract void Set(string key, object value, int time);

        /// <summary>
        /// 设置缓存对象，设置绝对过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存对象</param>
        /// <param name="absoluteExpiration">绝对过期时间，过了这个时间点，缓存即过期</param>
        public abstract void Set(string key, object value, DateTime absoluteExpiration);

        /// <summary>
        /// 设置缓存对象，设置相对过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存数据</param>
        /// <param name="slidingExpiration">滑动过期时间，在此时间内访问缓存，缓存将继续有效</param>
        public abstract void Set(string key, object value, TimeSpan slidingExpiration);

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">缓存键</param>
        public abstract void Remove(string key);

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        public abstract void Clear();

        public abstract bool Contains(string key);
    }
}
