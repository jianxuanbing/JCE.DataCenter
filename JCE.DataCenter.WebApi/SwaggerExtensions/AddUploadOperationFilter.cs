/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.WebApi.SwaggerExtensions
 * 文件名：AddUploadOperationFilter
 * 版本号：v1.0.0.0
 * 唯一标识：6811b067-9967-47a4-816a-bde27825aa55
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 16:40:04
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 16:40:04
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
    /// 添加上传过滤
    /// </summary>
    public class AddUploadOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var upload = apiDescription.ActionDescriptor.GetCustomAttributes<UploadAttribute>().Any();
            if (upload)
            {
                operation.consumes.Add("application/form-data");
                operation.parameters.Add(new Parameter()
                {
                    name = "file",
                    @in = "formData",
                    required = true,
                    type = "file"
                });
            }
        }
    }
}