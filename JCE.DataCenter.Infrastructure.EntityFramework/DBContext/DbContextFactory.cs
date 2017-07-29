/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.DBContext
 * 文件名：DbContextFactory
 * 版本号：v1.0.0.0
 * 唯一标识：851b5cb1-b991-4265-b2c2-5eebad5566b8
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 10:59:07
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 10:59:07
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using JCE.DataCenter.Infrastructure.EntityFramework.Strategy;
using JCE.DataCenter.Infrastructure.EntityFramework.Uow;

namespace JCE.DataCenter.Infrastructure.EntityFramework.DBContext
{
    /// <summary>
    /// 数据库上下文工厂
    /// </summary>
    public class DbContextFactory
    {
        private readonly IReadDbStrategy _readDbStrategy;
        private readonly string _masterDbConn;

        public DbContextFactory(IReadDbStrategy readDbStrategy,string connName)
        {
            _readDbStrategy = readDbStrategy;
            _masterDbConn = connName;
        }

        /// <summary>
        /// 获取主库上下文
        /// </summary>        
        /// <returns></returns>
        public DbContext GetWriteDbContext()
        {
            string key = typeof(DbContextFactory).Name + "WriteDbContext";
            DbContext dbContext =CallContext.GetData(key) as DbContext;
            if (dbContext == null)
            {
                dbContext=new WriteDbContext(_masterDbConn);
                CallContext.SetData(key,dbContext);
            }
            return dbContext;
        }        


        /// <summary>
        /// 获取从库上下文
        /// </summary>
        /// <returns></returns>
        public DbContext GetReadDbContext()
        {
            string key = typeof(DbContextFactory).Name + "ReadDbContext";
            DbContext dbContext=CallContext.GetData(key) as DbContext;
            if (dbContext == null)
            {
                dbContext = _readDbStrategy.GetDbContext();
                CallContext.SetData(key,dbContext);
            }
            return dbContext;
        }
    }
}
