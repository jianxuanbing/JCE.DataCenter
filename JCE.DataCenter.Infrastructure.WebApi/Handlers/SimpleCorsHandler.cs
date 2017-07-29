/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Handlers
 * 文件名：SimpleCorsHandler
 * 版本号：v1.0.0.0
 * 唯一标识：901739d2-aba3-47e6-b2c6-f56275669268
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 17:07:10
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 17:07:10
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JCE.Utils.Extensions;

namespace JCE.DataCenter.Infrastructure.WebApi.Handlers
{
    /// <summary>
    /// 简单Cors跨域处理器
    /// </summary>
    public class SimpleCorsHandler:DelegatingHandler
    {        
        private const string Origin = "Origin";
        private const string AccessControlRequestMethod = "Access-Control-Request-Method";
        private const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        private const string AccessControlAllowOrign = "Access-Control-Allow-Origin";
        private const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        private const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";
        private const string AccessControlAllowCredentials = "Access-Control-Allow-Credentials";
        // <add name = "Access-Control-Allow-Headers" value="Content-Type" />
        // <add name = "Access-Control-Allow-Methods" value="GET, POST, PUT, DELETE, OPTIONS" />
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isCrosRequest = request.Headers.Contains(Origin);
            bool isPrefilightRequest = request.Method == HttpMethod.Options;
            if (isCrosRequest)
            {
                Task<HttpResponseMessage> taskResult = null;
                if (isPrefilightRequest)
                {
                    taskResult = Task.Factory.StartNew<HttpResponseMessage>(() =>
                    {
                        HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                        response.Headers.Add(AccessControlAllowOrign,
                            request.Headers.GetValues(Origin).FirstOrDefault());
                        string method = request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();
                        //if (method != null)
                        //{
                        //    response.Headers.Add(AccessControlAllowMethods, method);
                        //}
                        string headers = string.Join(", ", request.Headers.GetValues(AccessControlRequestHeaders));
                        if (!string.IsNullOrWhiteSpace(headers))
                        {
                            response.Headers.Add(AccessControlAllowHeaders, headers);
                        }
                        response.Headers.Add(AccessControlAllowCredentials, "true");
                        return response;
                    }, cancellationToken);
                }
                else
                {
                    taskResult = base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(t =>
                    {
                        var response = t.Result;
                        response.Headers.Add(AccessControlAllowOrign,
                            request.Headers.GetValues(Origin).FirstOrDefault());
                        response.Headers.Add(AccessControlAllowCredentials, "true");
                        return response;
                    });
                }
                return taskResult;
            }
            return base.SendAsync(request, cancellationToken);
        }

        //private const string Origin = "Origin";
        //private const string AccessControlRequestMethod = "Access-Control-Request-Method";
        //private const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        //private const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        //private const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        //private const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";

        //// 重写基类的发送消息方法
        //protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        //{
        //    bool isCrosRequest = request.Headers.Contains(Origin);
        //    bool isPrefilightRequest = request.Method == HttpMethod.Options;
        //    if (isCrosRequest)
        //    {
        //        if (isPrefilightRequest)
        //        {
        //            return Task.Factory.StartNew(() =>
        //            {
        //                var response = new HttpResponseMessage(HttpStatusCode.OK);
        //                response.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());

        //                var currentAccessControlRequestMethod =
        //                    request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();

        //                if (currentAccessControlRequestMethod != null)
        //                {
        //                    response.Headers.Add(AccessControlAllowMethods, currentAccessControlRequestMethod);
        //                }

        //                var requestedHeaders = string.Join(", ", request.Headers.GetValues(AccessControlRequestHeaders));
        //                if (!requestedHeaders.IsNullOrEmpty())
        //                {
        //                    response.Headers.Add(AccessControlAllowHeaders, requestedHeaders);
        //                }
        //                return response;
        //            }, cancellationToken);
        //        }
        //        return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(t =>
        //        {
        //            var response = t.Result;
        //            response.Headers.Add(AccessControlAllowOrigin,
        //                request.Headers.GetValues(Origin).FirstOrDefault());
        //            return response;
        //        });
        //    }
        //    return base.SendAsync(request, cancellationToken);
        //}
    }
}
