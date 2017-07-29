/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Auditing
 * 文件名：CreationAuditedInitializer
 * 版本号：v1.0.0.0
 * 唯一标识：b715725e-2d49-4012-b382-86f8b3d37454
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 14:28:02
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 14:28:02
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JCE.Utils.Extensions;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Auditing
{
    /// <summary>
    /// 创建操作审计初始化器
    /// </summary>
    public class CreationAuditedInitializer
    {
        /// <summary>
        /// 实体
        /// </summary>
        private readonly DbEntityEntry _entity;
        

        /// <summary>
        /// 初始化一个<see cref="CreationAuditedInitializer"/>类型的实例
        /// </summary>
        /// <param name="entity">实体</param>
        private CreationAuditedInitializer(DbEntityEntry entity)
        {
            _entity = entity;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="entity">实体</param>
        public static void Init(DbEntityEntry entity)
        {
            new CreationAuditedInitializer(entity).Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var username = identity.Claims.Where(c => c.Type == "username").Select(c => c.Value).SingleOrDefault();
            if (username.IsNullOrEmpty())
            {
                username = "初始化";
            }
            var type = _entity.Entity.GetType();
            if (type.GetProperty("CreateTime") != null)
            {
                _entity.Property("CreateTime").CurrentValue = DateTime.Now;
            }
            if (type.GetProperty("Creater") != null)
            {
                //_entity.Property("Creater").CurrentValue = _userContext == null ? "初始化" : _userContext.UserName;
                _entity.Property("Creater").CurrentValue = username;
            }
            if (type.GetProperty("Status") != null)
            {
                _entity.Property("Status").CurrentValue = 1;
            }
        }
    }
}
