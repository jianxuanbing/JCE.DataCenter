/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Caching
 * 文件名：ICache
 * 版本号：v1.0.0.0
 * 唯一标识：ae1beace-a963-4651-b065-11ac284b3fbf
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 11:58:41
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 11:58:41
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

namespace JCE.DataCenter.Infrastructure.Caching
{
    /// <summary>
    /// 缓存操作约定
    /// </summary>
    public interface ICache:IDependency
    {
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        object Get(string key);

        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 获取当前缓存对象中的所有数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<object> GetAll();

        /// <summary>
        /// 获取当前缓存对象中的所有数据
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>();

        /// <summary>
        /// 设置缓存对象，使用默认配置
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存数据</param>
        void Set(string key, object value);

        /// <summary>
        /// 设置缓存对象，缓存时间单位：秒
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存对象</param>
        /// <param name="time">缓存过期时间，单位：秒</param>
        void Set(string key, object value, int time);

        /// <summary>
        /// 设置缓存对象，设置绝对过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存对象</param>
        /// <param name="absoluteExpiration">绝对过期时间，过了这个时间点，缓存即过期</param>
        void Set(string key, object value, DateTime absoluteExpiration);

        /// <summary>
        /// 设置缓存对象，设置相对过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="value">缓存数据</param>
        /// <param name="slidingExpiration">滑动过期时间，在此时间内访问缓存，缓存将继续有效</param>
        void Set(string key, object value, TimeSpan slidingExpiration);

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">缓存键</param>
        void Remove(string key);

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        void Clear();

        /// <summary>
        /// 是否包含指定缓存
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns></returns>
        bool Contains(string key);
    }
}
