/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Contexts
 * 文件名：WebContext
 * 版本号：v1.0.0.0
 * 唯一标识：c3f0405f-a515-4c55-a31f-5cab1d4ca5fc
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 14:05:50
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 14:05:50
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
using System.Web;

namespace JCE.DataCenter.Infrastructure.Contexts
{
    /// <summary>
    /// Web上下文
    /// </summary>
    internal class WebContext : IContext
    {
        /// <summary>
        /// 添加对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">对象</param>
        public void Add<T>(string key, T value)
        {
            if (HttpContext.Current == null)
                return;
            HttpContext.Current.Items[key] = value;
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        public T Get<T>(string key)
        {
            if (HttpContext.Current == null)
                return default(T);
            return (T)HttpContext.Current.Items[key];
        }

        /// <summary>
        /// 移除对象
        /// </summary>
        /// <param name="key">键名</param>
        public void Remove(string key)
        {
            if (HttpContext.Current == null)
                return;
            HttpContext.Current.Items.Remove(key);
        }
    }
}
