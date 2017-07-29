/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Applications
 * 文件名：ServiceBase
 * 版本号：v1.0.0.0
 * 唯一标识：cfa0eccd-0e62-43fa-9cd0-1892be54333b
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 16:29:59
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 16:29:59
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
using JCE.Utils.Logging;
using JCE.DataCenter.Infrastructure.Domain.Entities;

namespace JCE.DataCenter.Infrastructure.Applications
{
    /// <summary>
    /// 应用服务基类
    /// </summary>
    public abstract class ServiceBase : IServiceBase
    {
        
    }

    /// <summary>
    /// 应用服务基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class ServiceBase<TEntity,TKey>: ServiceBase,IServiceBase<TEntity> where TEntity:class,IEntity<TEntity,TKey>,new()
    {        
    }
}
