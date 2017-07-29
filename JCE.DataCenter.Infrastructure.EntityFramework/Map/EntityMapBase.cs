/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Map
 * 文件名：EntityMapBase
 * 版本号：v1.0.0.0
 * 唯一标识：7177fdd3-8404-430e-a41a-8d49fcfced2d
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 14:24:15
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 14:24:15
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Map
{
    /// <summary>
    /// 实体映射
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class EntityMapBase<TEntity> : EntityTypeConfiguration<TEntity>, IMap where TEntity : class
    {
        /// <summary>
        /// 初始化一个<see cref="EntityMapBase{TEntity}"/>类型的实例
        /// </summary>
        protected EntityMapBase()
        {
            MapTable();
            MapId();
            MapVersion();
            MapProperties();
            MapIgnores();
            MapAssociations();
        }

        /// <summary>
        /// 映射表
        /// </summary>
        protected abstract void MapTable();

        /// <summary>
        /// 映射标识
        /// </summary>
        protected virtual void MapId() { }

        /// <summary>
        /// 映射乐观离线锁
        /// </summary>
        protected virtual void MapVersion() { }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected virtual void MapProperties() { }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected virtual void MapAssociations() { }

        /// <summary>
        /// 映射忽略属性
        /// </summary>
        protected virtual void MapIgnores() { }

        /// <summary>
        /// 将配置添加到管理器
        /// </summary>
        /// <param name="registrar">配置管理器</param>
        public void AddTo(ConfigurationRegistrar registrar)
        {
            registrar.Add(this);
        }
    }
}
