/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Handlers
 * 文件名：RequestResponseTraceHandlerHandler
 * 版本号：v1.0.0.0
 * 唯一标识：9ddaae48-2762-4d97-a834-1589ac2f9268
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/23 18:43:03
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/23 18:43:03
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JCE.DataCenter.Infrastructure.WebApi.Extensions;
using JCE.DataCenter.Infrastructure.WebApi.Logging;

namespace JCE.DataCenter.Infrastructure.WebApi.Handlers
{
    /// <summary>
    /// 消息处理——请求响应跟踪
    /// </summary>
    public class RequestResponseTraceHandlerHandler:DelegatingHandler
    {
        private static readonly string[] IgnoreMonitorAction = {"Upload"};

        /// <summary>
        /// 日志信息缓存键
        /// </summary>
        private static readonly string _loggingInfoKey = "loggingInfo";

        /// <summary>
        /// 日志记录仓储
        /// </summary>
        private readonly ILoggingRepository _repository;

        /// <summary>
        /// 初始化一个<see cref="RequestResponseTraceHandlerHandler"/>类型的实例
        /// </summary>
        /// <param name="repository">日志记录仓储</param>
        public RequestResponseTraceHandlerHandler(ILoggingRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// 初始化一个<see cref="RequestResponseTraceHandlerHandler"/>类型的实例
        /// </summary>
        /// <param name="innerHandler">内部消息处理器</param>
        /// <param name="repository">日志记录仓储</param>
        public RequestResponseTraceHandlerHandler(HttpMessageHandler innerHandler, ILoggingRepository repository)
            : base(innerHandler)
        {
            this._repository = repository;
        }

        // 重写发送消息处理方法，记录请求信息以及响应信息
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var action=request.GetActionName();
            // 忽略上传监控

            if (action == null || IgnoreMonitorAction.Contains(action))
            {
                return base.SendAsync(request, cancellationToken);
            }

            // 记录 请求信息
            LogRequestLoggingInfo(request);

            // 执行请求
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                // 提取响应日志信息，然后记录信息
                LogResponseLoggingInfo(response);
                return response;
            });
        }

        /// <summary>
        /// 记录请求日志信息
        /// </summary>
        /// <param name="request">http请求</param>
        private void LogRequestLoggingInfo(HttpRequestMessage request)
        {
            var info = new ApiLoggingInfo()
            {
                HttpMethod = request.Method.Method,
                UriAccessed = request.RequestUri.AbsoluteUri,
                IpAddress = request.GetClientIpAddress(),
                LoggingLevel = LoggingLevel.Trace,
                StartTime = DateTime.Now
            };

            ExtractMessageHeadersIntoLoggingInfo(info, request.Headers.ToList());

            if (request.Content != null)
            {
                request.Content.ReadAsByteArrayAsync().ContinueWith(task =>
                {
                    info.BodyContent = Encoding.UTF8.GetString(task.Result);                    
                });
                request.Properties.Add(_loggingInfoKey,info);
                return;
            }
            request.Properties.Add(_loggingInfoKey, info);
        }

        /// <summary>
        /// 记录响应日志信息
        /// </summary>
        /// <param name="response">http响应</param>
        private void LogResponseLoggingInfo(HttpResponseMessage response)
        {
            object loggingInfoObject = null;
            if (!response.RequestMessage.Properties.TryGetValue(_loggingInfoKey, out loggingInfoObject))
            {
                return;
            }
            var info = loggingInfoObject as ApiLoggingInfo;
            if (info == null)
            {
                return;                
            }
            info.ResponseStatusCode = response.StatusCode;
            info.ResponseStatusMessage = response.ReasonPhrase;
            info.EndTime=DateTime.Now;                        
            //if (response.RequestMessage != null)
            //{
            //    info.HttpMethod = response.RequestMessage.Method.Method;
            //    info.UriAccessed = response.RequestMessage.RequestUri.AbsoluteUri;
            //    info.IpAddress = response.RequestMessage.GetClientIpAddress();
            //}
            info.TotalTime = (info.EndTime - info.StartTime).TotalMilliseconds;

            if (response.Content != null)
            {
                response.Content.ReadAsByteArrayAsync().ContinueWith(task =>
                {
                    var responseMsg = Encoding.UTF8.GetString(task.Result);
                    info.BodyContent = responseMsg;
                    this._repository.Log(info);
                });
                return;
            }
            this._repository.Log(info);
        }

        /// <summary>
        /// 提取消息头并记录到日志信息
        /// </summary>
        /// <param name="info">api日志信息</param>
        /// <param name="headers">http请求头</param>
        private void ExtractMessageHeadersIntoLoggingInfo(ApiLoggingInfo info,
            List<KeyValuePair<string, IEnumerable<string>>> headers)
        {
            headers.ForEach(h =>
            {
                // convert the header values into one long string from a series of IEnumerable<string> values so it looks for like a HTTP header
                var headerValues=new StringBuilder();

                if (h.Value != null)
                {
                    foreach (var hv in h.Value)
                    {
                        if (headerValues.Length > 0)
                        {
                            headerValues.Append(",");
                        }
                        headerValues.Append(hv);
                    }
                }
                info.Headers.Add(string.Format("{0}: {1}",h.Key,headerValues.ToString()));
            });
        }
    }
}
