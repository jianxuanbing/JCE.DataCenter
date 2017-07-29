/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.DBContext
 * 文件名：WriteDbContext
 * 版本号：v1.0.0.0
 * 唯一标识：e5df578e-c45f-4100-8585-ad0b10618f2e
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 11:04:08
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 11:04:08
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
    /// 主库，写入数据
    /// </summary>
    public class WriteDbContext:DbContext
    {
        public WriteDbContext(string connName = "") : base(string.IsNullOrEmpty(connName) ? "connWriteStr" : connName)
        {
            Configuration.AutoDetectChangesEnabled = true;
        }

        public WriteDbContext() : this("name=connWriteStr")
        {            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
