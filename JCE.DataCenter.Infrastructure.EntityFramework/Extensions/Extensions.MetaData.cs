/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Extensions
 * 文件名：Extensions
 * 版本号：v1.0.0.0
 * 唯一标识：3ec5b027-11fc-4a60-9701-5d7c26149656
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/29 12:00:53
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/29 12:00:53
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
using EntityFramework;
using EntityFramework.Extensions;
using EntityFramework.Mapping;
using JCE.DataCenter.Infrastructure.Domain.Entities;
using JCE.DataCenter.Infrastructure.Domain.Repositories;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Extensions
{
    // EF元数据扩展
    public static partial class Extensions
    {
        #region GetMetaData(获取实体元数据)
        /// <summary>
        /// 获取实体元数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="context">数据上下文</param>
        /// <returns></returns>
        public static EntityMap GetMetaData<TEntity>(this DbContext context) where TEntity : class
        {
            return context.Set<TEntity>().ToObjectQuery().GetEntityMap<TEntity>();
        }

        /// <summary>
        /// 获取实体元数据
        /// </summary>
        /// <param name="context">数据上下文</param>
        /// <param name="type">实体类型</param>
        /// <returns></returns>
        public static EntityMap GetMetaData(this DbContext context, Type type)
        {
            var provider = Locator.Current.Resolve<IMappingProvider>();
            return provider.GetEntityMap(type, context);
        }

        /// <summary>
        /// 获取实体元数据
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="repository">仓储</param>
        /// <returns></returns>
        public static EntityMap GetMetaData<TEntity, TKey>(this IRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TEntity, TKey>
        {
            var context = (DbContext)repository.GetUnitOfWork();
            return context.GetMetaData<TEntity>();
        }
        #endregion

    }
}
