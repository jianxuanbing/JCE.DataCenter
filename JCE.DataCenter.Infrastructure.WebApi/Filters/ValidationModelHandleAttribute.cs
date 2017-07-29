/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Filters
 * 文件名：ValidationModelAttribute
 * 版本号：v1.0.0.0
 * 唯一标识：3a2b8c14-c3aa-46f4-b561-752f0fcd781b
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/18 18:10:41
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/18 18:10:41
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
    /// 验证实体处理
    /// </summary>
    public class ValidationModelHandleAttribute:ActionFilterAttribute
    {
        // 重写实体验证
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var result =
                    actionContext.ModelState.Where(x => x.Value.Errors.Count > 0)
                        .Select(
                            x =>
                                new ApiResult()
                                {
                                    Code = ResultCode.Fail,
                                    Message = string.Format("{0} {1}", x.Key, x.Value.Errors.First().ErrorMessage)
                                }).ToList();
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, result);
            }
        }
    }
}
