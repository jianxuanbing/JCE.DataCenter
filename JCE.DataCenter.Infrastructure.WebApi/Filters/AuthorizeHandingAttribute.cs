/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Filters
 * 文件名：AuthorizeHandingAttribute
 * 版本号：v1.0.0.0
 * 唯一标识：8594e167-b566-4ef3-b0fd-bc73fdda9c80
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/13 16:43:42
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/13 16:43:42
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
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using JCE.Utils.Extensions;
using JCE.DataCenter.Infrastructure.CommonModel;

namespace JCE.DataCenter.Infrastructure.WebApi.Filters
{
    /// <summary>
    /// 授权认证处理
    /// </summary>
    public class AuthorizeHandingAttribute:AuthorizationFilterAttribute
    {
        // 重写基类方法-实现登录认证过滤
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var isAnonymous =
                actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any() ||
                actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>()
                    .Any();

            if (isAnonymous)
            {
                return;
            }
            ApiController apiController = (ApiController) actionContext.ControllerContext.Controller;
            if (!apiController.User.Identity.IsAuthenticated)
            {
                ApiResult result=new ApiResult();
                result.Message = ResultCode.LoginTimeout.Description();
                result.Code=ResultCode.LoginTimeout;

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, result,
                    "application/json");
            }            
        }
    }
}
