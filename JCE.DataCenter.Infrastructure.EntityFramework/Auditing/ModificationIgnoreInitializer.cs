/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Auditing
 * 文件名：ModificationIgnoreInitializer
 * 版本号：v1.0.0.0
 * 唯一标识：2cdc3f88-5ac8-4632-830e-909768be9368
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 14:30:18
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 14:30:18
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Auditing
{
    /// <summary>
    /// 修改操作忽略初始化器
    /// </summary>
    public class ModificationIgnoreInitializer
    {
        /// <summary>
        /// 实体
        /// </summary>
        private readonly DbEntityEntry _entity;

        /// <summary>
        /// 初始化一个<see cref="ModificationIgnoreInitializer"/>类型的实例
        /// </summary>
        /// <param name="entity">实体</param>
        private ModificationIgnoreInitializer(DbEntityEntry entity)
        {
            _entity = entity;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="entity">实体</param>
        public static void Init(DbEntityEntry entity)
        {
            new ModificationIgnoreInitializer(entity).Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            var type = _entity.Entity.GetType();
            if (type.GetProperty("CreateTime") != null)
            {
                _entity.Property("CreateTime").IsModified = false;
            }
            if (type.GetProperty("Creater") != null)
            {
                _entity.Property("Creater").IsModified = false;
            }
        }
    }
}
