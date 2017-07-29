/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.WebApi.SwaggerExtensions
 * 文件名：AuthTokenOperation
 * 版本号：v1.0.0.0
 * 唯一标识：aa239020-8c1d-4338-92ba-3ef45d6abe93
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 16:39:31
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 16:39:31
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace JCE.DataCenter.WebApi.SwaggerExtensions
{
    /// <summary>
    /// 认证令牌操作
    /// </summary>
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/oauth2/token", new PathItem()
            {
                post = new Operation
                {
                    tags = new List<string>() { "Auth" },
                    consumes = new List<string>()
                    {
                        "application/x-www-form-urlencoded"
                    },
                    parameters = new List<Parameter>()
                    {
                        new Parameter()
                        {
                            name = "username",
                            @in = "formData",
                            required = true,
                            type = "string",
                            description = "账号"
                        },
                        new Parameter()
                        {
                            name = "password",
                            @in = "formData",
                            @default = null,
                            type = "string",
                            required = false,
                            description = "密码"
                        },
                        new Parameter()
                        {
                            name = "grant_type",
                            @in = "formData",
                            @default = "password",
                            required = true,
                            type = "string",
                            description = "授权类型,默认password"
                        },
                        new Parameter()
                        {
                            name="scope",
                            @in="formData",
                            required = true,
                            type = "Array[string]",
                            description = "登录类型,前端:pc,后端:admin"
                        }
                    }
                }
            });
        }
    }
}