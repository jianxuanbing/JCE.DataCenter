/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Aop
 * 文件名：CachingCallHandlerAttribute
 * 版本号：v1.0.0.0
 * 唯一标识：36ba2c82-3b23-4d8c-a38d-ac19af2d7d63
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 14:05:24
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 14:05:24
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
using Castle.Core.Internal;

namespace JCE.DataCenter.Infrastructure.Aop
{
    /// <summary>
    /// 缓存处理
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CachingCallHandlerAttribute:Attribute
    {
        public readonly TimeSpan? ExpirationTime;

        public CachingCallHandlerAttribute(string expiretionTime = "")
        {
            if (!expiretionTime.IsNullOrEmpty())
            {
                TimeSpan expirationTimeSpan;
                if (TimeSpan.TryParse(expiretionTime, out expirationTimeSpan))
                {
                    throw new ArgumentException("输入的过期时间格式不正确!");
                }
                this.ExpirationTime = expirationTimeSpan;
            }
        }
    }
}
