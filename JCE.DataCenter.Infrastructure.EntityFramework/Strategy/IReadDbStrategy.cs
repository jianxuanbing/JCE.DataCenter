/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Strategy
 * 文件名：IReadDbStrategy
 * 版本号：v1.0.0.0
 * 唯一标识：bb001122-7303-4013-beb1-a52da57334c3
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 10:59:47
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 10:59:47
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Strategy
{
    /// <summary>
    /// 从数据库读取策略接口
    /// </summary>
    public interface IReadDbStrategy
    {
        /// <summary>
        /// 获取读库
        /// </summary>
        /// <returns></returns>
        DbContext GetDbContext();
    }
}
