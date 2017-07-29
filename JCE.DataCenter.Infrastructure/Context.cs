/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure
 * 文件名：Context
 * 版本号：v1.0.0.0
 * 唯一标识：4ae0ab68-53b8-4466-8025-6497989ef858
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 14:06:27
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 14:06:27
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
using JCE.DataCenter.Infrastructure.Contexts;

namespace JCE.DataCenter.Infrastructure
{
    /// <summary>
    /// 上下文
    /// </summary>
    public static class Context
    {
        /// <summary>
        /// 初始化上下文
        /// </summary>
        static Context()
        {
            if (IsWeb)
                _context = new WebContext();
            else
                _context = new WindowsContext();
        }

        /// <summary>
        /// 上下文
        /// </summary>
        private static readonly IContext _context;

        /// <summary>
        /// 是否Web系统
        /// </summary>
        private static bool IsWeb
        {
            get { return HttpContext.Current != null; }
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">对象</param>
        public static void Add<T>(string key, T value)
        {
            _context.Add(key, value);
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        public static T Get<T>(string key)
        {
            return _context.Get<T>(key);
        }

        /// <summary>
        /// 移除对象
        /// </summary>
        /// <param name="key">键名</param>
        public static void Remove(string key)
        {
            _context.Remove(key);
        }
    }
}
