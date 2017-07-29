/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.DBContext
 * 文件名：BaseReadDbContext
 * 版本号：v1.0.0.0
 * 唯一标识：b41ba490-ab28-4f1d-a02c-ee8879904ef6
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 11:12:50
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 11:12:50
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.EntityFramework.DBContext
{
    /// <summary>
    /// 从库上下文基类
    /// </summary>
    public class BaseReadDbContext:DbContext
    {
        static BaseReadDbContext()
        {
            Database.SetInitializer<BaseReadDbContext>(null);
        }

        public BaseReadDbContext(string connReadStr) : base(connReadStr)
        {
            Configuration.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            throw new InvalidOperationException("只读数据库，不允许写入！");
        }
    }
}
