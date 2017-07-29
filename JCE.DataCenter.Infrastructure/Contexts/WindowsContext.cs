/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Contexts
 * 文件名：WindowsContext
 * 版本号：v1.0.0.0
 * 唯一标识：85704eae-2811-4dfd-9002-f7ae2f177c71
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 14:06:08
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 14:06:08
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

namespace JCE.DataCenter.Infrastructure.Contexts
{
    /// <summary>
    /// Windows上下文
    /// </summary>
    internal class WindowsContext : IContext
    {
        /// <summary>
        /// 添加对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">对象</param>
        public void Add<T>(string key, T value)
        {
            LocalDataStoreSlot slot = System.Threading.Thread.GetNamedDataSlot(key);
            System.Threading.Thread.SetData(slot, value);
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        public T Get<T>(string key)
        {
            LocalDataStoreSlot slot = System.Threading.Thread.GetNamedDataSlot(key);
            return (T)System.Threading.Thread.GetData(slot);
        }

        /// <summary>
        /// 移除对象
        /// </summary>
        /// <param name="key">键名</param>
        public void Remove(string key)
        {
            LocalDataStoreSlot slot = System.Threading.Thread.GetNamedDataSlot(key);
            System.Threading.Thread.SetData(slot, null);
        }
    }
}
