/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Extensions
 * 文件名：HttpMessageExtensions
 * 版本号：v1.0.0.0
 * 唯一标识：c811f643-047b-4975-bbf9-5c94774bf788
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/10 23:53:21
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/10 23:53:21
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;

namespace JCE.DataCenter.Infrastructure.WebApi.Extensions
{
    /// <summary>
    /// HttpRequestMessage扩展方法
    /// </summary>
    public static class HttpMessageExtensions
    {
        
        private const string HttpContextKey = "MS_HttpContext";
        private const string OwinContextKey = "MS_OwinContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";

        #region GetClientIpAddress(获取客户端IP)
        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <param name="request">Http请求消息</param>
        /// <returns></returns>
        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey(HttpContextKey))
            {
                dynamic ctx = request.Properties[HttpContextKey];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }
            if (request.Properties.ContainsKey(OwinContextKey))
            {
                dynamic ctx = request.Properties[OwinContextKey];
                if (ctx != null)
                {
                    return ctx.Request.RemoteIpAddress;
                }
            }
            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }
            return null;
        }
        #endregion

        #region GetAreaName(获取区域信息)
        /// <summary>
        /// 获取区域信息，如不存在则返回null
        /// </summary>
        /// <param name="request">Http消息请求</param>
        /// <returns></returns>
        public static string GetAreaName(this HttpRequestMessage request)
        {
            const string key = "area";
            return GetRouteInfo(key, request);
        }
        #endregion

        #region GetControllerName(获取控制器名称)
        /// <summary>
        /// 获取控制器名称
        /// </summary>
        /// <param name="request">Http消息请求</param>
        /// <returns></returns>
        public static string GetControllerName(this HttpRequestMessage request)
        {
            const string key = "controller";
            return GetRouteInfo(key, request);
        }
        #endregion

        #region GetActionName(获取操作方法名称)
        /// <summary>
        /// 获取操作方法名称
        /// </summary>
        /// <param name="request">Http请求消息</param>
        /// <returns></returns>
        public static string GetActionName(this HttpRequestMessage request)
        {
            const string key = "action";
            return GetRouteInfo(key, request);
        }
        #endregion

        #region GetRequestType(获取请求类型)
        /// <summary>
        /// 获取请求类型
        /// </summary>
        /// <param name="request">Http请求消息</param>
        /// <returns></returns>
        public static string GetRequestType(this HttpRequestMessage request)
        {
            return request.Method.Method;
        }
        #endregion

        #region GetRouteInfo(获取路由信息)
        /// <summary>
        /// 获取路由信息
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="request">Http请求消息</param>
        /// <returns></returns>
        private static string GetRouteInfo(string name, HttpRequestMessage request)
        {
            object value;
            IHttpRouteData data = request.GetRouteData();
            if (data.Route.DataTokens == null || data.Route.DataTokens.Count == 0)
            {
                if (data.Values.TryGetValue(name, out value))
                {
                    return value.ToString();
                }
                return null;
            }
            return data.Route.DataTokens.TryGetValue(name, out value) ? value.ToString() : null;
        }
        #endregion

        #region IsLocal(是否本地请求)
        /// <summary>
        /// 返回请求<see cref="HttpRequestMessage"/>是否来自本地
        /// </summary>
        /// <param name="request">Http请求消息</param>
        /// <returns></returns>
        public static bool IsLocal(this HttpRequestMessage request)
        {
            var localFlag = request.Properties["MS_IsLocal"] as Lazy<bool>;
            return localFlag != null && localFlag.Value;
        }
        #endregion
    }
}
