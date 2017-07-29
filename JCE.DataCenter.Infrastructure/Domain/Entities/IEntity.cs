/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Domain.Entities
 * 文件名：IEntity
 * 版本号：v1.0.0.0
 * 唯一标识：3dc29762-7e8d-4e6a-a7b4-726293233ddf
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 15:44:04
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 15:44:04
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

namespace JCE.DataCenter.Infrastructure.Domain.Entities
{
    /// <summary>
    /// 实体
    /// </summary>
    public interface IEntity
    {
        
    }

    /// <summary>
    /// 实体
    /// </summary>
    /// <typeparam name="TKey">实体类型</typeparam>
    public interface IEntity<out TKey>:IEntity
    {
        ///// <summary>
        ///// 标识
        ///// </summary>
        //TKey Id { get;}
    }

    /// <summary>
    /// 实体
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">标识类型</typeparam>
    public interface IEntity<in TEntity, out TKey> : IEntity<TKey> where TEntity : IEntity
    {
        
    }
}
