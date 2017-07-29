/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Strategy
 * 文件名：RandomStrategy
 * 版本号：v1.0.0.0
 * 唯一标识：fcb82dfe-f4e7-4078-86ad-971b7eba8cdf
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 11:10:27
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 11:10:27
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
using JCE.DataCenter.Infrastructure.EntityFramework.DBContext;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Strategy
{
    /// <summary>
    /// 随机策略
    /// </summary>
    public class RandomStrategy:IReadDbStrategy
    {
        /// <summary>
        /// 所有从库类型
        /// </summary>
        public static List<Type> DbTypes;

        static RandomStrategy()
        {
            LoadDbs();
        }

        /// <summary>
        /// 加载所有的从库类型
        /// </summary>
        private static void LoadDbs()
        {
            DbTypes=new List<Type>();
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.BaseType == typeof(BaseReadDbContext))
                {
                    DbTypes.Add(type);
                }
            }
        }

        public DbContext GetDbContext()
        {
            int randomIndex=new Random().Next(0,DbTypes.Count);
            var dbType = DbTypes[randomIndex];
            var dbContext = Activator.CreateInstance(dbType) as DbContext;
            return dbContext;
        }
    }
}
