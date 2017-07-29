/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Caching
 * 文件名：ICacheProvider
 * 版本号：v1.0.0.0
 * 唯一标识：6ac89445-342e-4891-8057-f1da25cf6996
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 13:05:33
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 13:05:33
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
    /// 缓存提供者约定，用于创建并管理缓存对象
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// 获取缓存对象
        /// </summary>
        /// <param name="regionName">缓存区域名称</param>
        /// <returns></returns>
        ICache GetCache(string regionName);
    }
}
