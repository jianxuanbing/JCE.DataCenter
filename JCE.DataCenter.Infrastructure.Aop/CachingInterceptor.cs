/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Aop
 * 文件名：CachingInterceptor
 * 版本号：v1.0.0.0
 * 唯一标识：0610889b-8d39-4062-8759-cb205c85362f
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 14:09:38
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 14:09:38
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
using Castle.DynamicProxy;
using JCE.DataCenter.Infrastructure.Caching;
using JCE.Utils.Extensions;

namespace JCE.DataCenter.Infrastructure.Aop
{
    /// <summary>
    /// 缓存 拦截器
    /// </summary>
    public class CachingInterceptor: IInterceptor
    {
        private static readonly ICache _cache = CacheManager.GetCacher<CachingInterceptor>();
        public void Intercept(IInvocation invocation)
        {
            var cacheAttribute = invocation.Method.GetAttribute<CachingCallHandlerAttribute>();
            if (cacheAttribute == null)
            {
                invocation.Proceed();
                return;
            }

            var cacheKey = string.Concat(invocation.TargetType.FullName, ".", invocation.Method.Name, "(",
                string.Join(",", invocation.Arguments), ")");
            if (_cache.Contains(cacheKey))
            {
                invocation.ReturnValue = _cache.Get(cacheKey);
            }
            else
            {
                invocation.Proceed();
                if (!cacheAttribute.ExpirationTime.IsNull())
                {
                    _cache.Set(cacheKey, invocation.ReturnValue,cacheAttribute.ExpirationTime.SafeValue());
                }
                else
                {
                    _cache.Set(cacheKey,invocation.ReturnValue);                    
                }                
            }
        }

    }
}
