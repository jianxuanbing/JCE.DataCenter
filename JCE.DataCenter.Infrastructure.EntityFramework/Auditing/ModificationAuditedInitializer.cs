/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Auditing
 * 文件名：ModificationAuditedInitializer
 * 版本号：v1.0.0.0
 * 唯一标识：7492132c-2027-42c5-a647-5cc3b7959b0b
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 14:29:28
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 14:29:28
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
    /// 修改操作审计初始化器
    /// </summary>
    public class ModificationAuditedInitializer
    {
        /// <summary>
        /// 实体
        /// </summary>
        private readonly DbEntityEntry _entity;

        /// <summary>
        /// 初始化一个<see cref="ModificationAuditedInitializer"/>类型的实例
        /// </summary>
        /// <param name="entity">实体</param>
        private ModificationAuditedInitializer(DbEntityEntry entity)
        {
            _entity = entity;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="entity">实体</param>
        public static void Init(DbEntityEntry entity)
        {
            new ModificationAuditedInitializer(entity).Init();
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
            if (type.GetProperty("EditTime") != null)
            {
                _entity.Property("EditTime").CurrentValue = DateTime.Now;
            }
            if (type.GetProperty("Editor") != null)
            {
                //_entity.Property("Editor").CurrentValue = _userContext == null ? "初始化" : _userContext.UserName;

                _entity.Property("Editor").CurrentValue = username;
            }
        }
    }
}
