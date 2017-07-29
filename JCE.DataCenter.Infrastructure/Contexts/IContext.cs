/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Context
 * 文件名：IContext
 * 版本号：v1.0.0.0
 * 唯一标识：98ca0f07-8bf0-4133-acbf-e67eb51e1824
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 14:05:11
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 14:05:11
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
    /// 上下文
    /// </summary>
    internal interface IContext
    {
        /// <summary>
        /// 添加对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">对象</param>
        void Add<T>(string key, T value);
        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        T Get<T>(string key);
        /// <summary>
        /// 移除对象
        /// </summary>
        /// <param name="key">键名</param>
        void Remove(string key);
    }
}
