/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Filters
 * 文件名：ExceptionHandlingAttribute
 * 版本号：v1.0.0.0
 * 唯一标识：4cf270ef-c62d-449d-898e-ba07ddabeba6
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/10 23:45:50
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/10 23:45:50
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using JCE.Utils.Extensions;
using JCE.DataCenter.Infrastructure.CommonModel;
using JCE.DataCenter.Infrastructure.Exceptions;
using JCE.DataCenter.Infrastructure.Logs;
using JCE.DataCenter.Infrastructure.WebApi.Extensions;
using JCE.DataCenter.Logs.Log4Net;

namespace JCE.DataCenter.Infrastructure.WebApi.Filters
{
    /// <summary>
    /// WebApi异常处理
    /// </summary>
    public class ExceptionHandlingAttribute:ExceptionFilterAttribute
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        private static readonly ILog Logger = Log.GetLog(typeof(ExceptionHandlingAttribute));

        /// <summary>
        /// 错误类型状态码映射字典
        /// </summary>
        public static IDictionary<Type, HttpStatusCode> Mapping { get; private set; }

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static ExceptionHandlingAttribute()
        {
            Mapping = new Dictionary<Type, HttpStatusCode>()
            {
                {typeof(ArgumentNullException), HttpStatusCode.BadRequest},
                {typeof(ArgumentException), HttpStatusCode.BadRequest}
            };
        }

        // 重写基类的异常处理方法
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {            
            if (actionExecutedContext.Exception == null)
            {
                return;
            }
            HttpRequestMessage request = actionExecutedContext.Request;
            Exception exception = actionExecutedContext.Exception;
            

            string ip = actionExecutedContext.ActionContext.Request.GetClientIpAddress();
            string user = actionExecutedContext.ActionContext.RequestContext.Principal.Identity.Name;
            string msg = "User:{0}，IP:{1}，Message:{2}".FormatWith(user, ip, exception.Message);

            if (exception is BusinessException)
            {
                actionExecutedContext.Response = request.CreateResponse(HttpStatusCode.OK,
                    new ApiResult()
                    {
                        Code = ResultCode.Fail,
                        Message = exception.Message ?? ResultCode.Fail.Description()
                    });
                Logger.Info(msg);
            }
            else
            {
                string message = "网络繁忙，请勿频繁点击!";
                actionExecutedContext.Response = actionExecutedContext.Response == null
                    ? request.CreateResponse(HttpStatusCode.OK, new ApiResult()
                    {
                        Code = ResultCode.Error,
                        Message = message
                    })
                    : request.CreateResponse(HttpStatusCode.OK, new ApiResult()
                    {
                        Code = ResultCode.Error,
                        Message = actionExecutedContext.Response.StatusCode.ToChsText()
                    });

                var param = actionExecutedContext.ActionContext.ActionArguments.ToJson();
                string area = request.GetAreaName();
                string controller = request.GetControllerName();
                string action = request.GetActionName();
                string requestType = request.GetRequestType();
                Logger.Rquest(area, controller, action, requestType);
                Logger.Params(param);
                Logger.Exception(exception);
                Logger.Error();
            }                                    

            base.OnException(actionExecutedContext);
        }
    }
}
