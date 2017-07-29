/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Filters
 * 文件名：ResultHandleAttribute
 * 版本号：v1.0.0.0
 * 唯一标识：4ffa694e-3cc1-4b8e-9f6f-e3ba191e4530
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 18:01:50
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 18:01:50
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
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using JCE.DataCenter.Infrastructure.CommonModel;

namespace JCE.DataCenter.Infrastructure.WebApi.Filters
{
    /// <summary>
    /// 响应结果处理
    /// </summary>
    public class ResultHandleAttribute:ActionFilterAttribute
    {
        // 重写基类方法-实现结果过滤，统一返回结果
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {            
            if (actionExecutedContext.Exception != null)
            {
                throw actionExecutedContext.Exception;
            }
            var actionContext = actionExecutedContext.ActionContext;

            // 忽略结果处理
            var ignore = actionContext.ActionDescriptor.GetCustomAttributes<IgnoreResultHandleAttribute>().Any() ||
                         actionContext.ControllerContext.ControllerDescriptor
                             .GetCustomAttributes<IgnoreResultHandleAttribute>().Any();
            if (!ignore)
            {                
                var response = actionContext.Response;
                ApiResult result;                
                if (response != null && response.Content != null)
                {
                    result = new ApiResult<object>();
                    ((ApiResult<object>) result).Data = response.Content.ReadAsAsync<object>().Result;
                }
                else
                {
                    result=new ApiResult();
                }
                result.Code = ResultCode.Success;


                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK, result,
                    "application/json");
            }
            //base.OnActionExecuted(actionExecutedContext);
        }
    }
}
