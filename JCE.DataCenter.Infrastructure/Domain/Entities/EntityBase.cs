/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Domain.Entities
 * 文件名：EntityBase
 * 版本号：v1.0.0.0
 * 唯一标识：297da863-671b-4aa0-ab9f-71f4ab5831c6
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 15:47:48
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 15:47:48
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
    /// 实体基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class EntityBase<TEntity,TKey>:IEntity<TEntity,TKey> where TEntity:IEntity
    {
        ///// <summary>
        ///// 标识
        ///// </summary>
        //public TKey Id { get; protected set; }

        //protected EntityBase(TKey id)
        //{
        //    Id = id;
        //}
    }
}
