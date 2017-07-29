/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Repositories
 * 文件名：RepositoryBase
 * 版本号：v1.0.0.0
 * 唯一标识：97a007f2-e1df-4883-bba5-be76b90fa90f
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 16:19:23
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 16:19:23
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
using JCE.DataCenter.Infrastructure.Domain.Entities;
using JCE.DataCenter.Infrastructure.Domain.Uow;
using JCE.DataCenter.Infrastructure.EntityFramework.DBContext;
using JCE.DataCenter.Infrastructure.EntityFramework.Repositories;

namespace JCE.DataCenter.Repositories
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class RepositoryBase<TEntity,TKey>:Repository<TEntity,TKey> where TEntity:EntityBase<TEntity,TKey>
    {
        /// <summary>
        /// 初始化一个<see cref="RepositoryBase{TEntity,TKey}"/>类型的实例
        /// </summary>
        /// <param name="factory">数据上下文工厂</param>
        protected RepositoryBase(DbContextFactory factory) : base(factory)
        {
        }

        /// <summary>
        /// 初始化一个<see cref="RepositoryBase{TEntity,TKey}"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected RepositoryBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Context = (DataCenterUnitOfWork) unitOfWork;
        }

        /// <summary>
        /// 数据中心数据上下文
        /// </summary>
        protected DataCenterUnitOfWork Context { get; set; }
    }
}
