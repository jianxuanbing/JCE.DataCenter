/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Repositories
 * 文件名：JCE.DataCenterUnitOfWork
 * 版本号：v1.0.0.0
 * 唯一标识：d509aadc-b799-4206-ba6c-cde00be21778
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 16:22:51
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 16:22:51
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.EntityFramework.Uow;

namespace JCE.DataCenter.Repositories
{
    /// <summary>
    /// 紫云来项目工作单元
    /// </summary>
    public partial class DataCenterUnitOfWork:UnitOfWork,IDataCenterUnitOfWork
    {
        #region 静态构造函数
        /// <summary>
        /// 初始化紫云来项目工作单元
        /// </summary>
        static DataCenterUnitOfWork()
        {
            System.Data.Entity.Database.SetInitializer<DataCenterUnitOfWork>(null);
        }
        #endregion

        #region Constructor(构造函数)
        /// <summary>
        /// 初始化一个<see cref="DataCenterUnitOfWork"/>类型的实例
        /// </summary>
        public DataCenterUnitOfWork() : this("JCE.DataCenter_Database")
        {

        }
        /// <summary>
        /// 初始化一个<see cref="DataCenterUnitOfWork"/>类型的实例
        /// </summary>
        /// <param name="connectionName">数据库连接字符串</param>
        public DataCenterUnitOfWork(string connectionName) : base(connectionName)
        {
        }        
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();            
        }
    }
}
