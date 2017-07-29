/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.WebApi.App_Start
 * 文件名：FilterConfig
 * 版本号：v1.0.0.0
 * 唯一标识：16783710-9f59-4b03-a52a-964d61085290
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/13 12:41:01
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/13 12:41:01
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using JCE.DataCenter.Infrastructure.WebApi.Filters;
using JCE.DataCenter.Infrastructure.WebApi.Initialize;

namespace JCE.DataCenter.WebApi
{
    /// <summary>
    /// 过滤器配置
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="config">Http配置</param>
        public static void Configure(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeHandingAttribute());//添加授权处理
            config.Filters.Add(new ExceptionHandlingAttribute());//添加WebApi异常过滤器
            config.Filters.Add(new ResultHandleAttribute());//添加响应结果处理过滤器
            //config.Filters.Add(new ValidationModelHandleAttribute());//添加验证实体处理器
            ResponseFormatterHandler.Formatter(config);//响应数据格式化过滤处理
        }
    }
}