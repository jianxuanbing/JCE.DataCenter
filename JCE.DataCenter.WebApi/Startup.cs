/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.WebApi
 * 文件名：Startup
 * 版本号：v1.0.0.0
 * 唯一标识：a9ed5179-d8fd-4b19-92ba-7c4c41437a62
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 16:46:35
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 16:46:35
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using JCE.DataCenter.WebApi;
using JCE.DataCenter.WebApi.SignalR;

[assembly:OwinStartup(typeof(Startup))]

namespace JCE.DataCenter.WebApi
{
    /// <summary>
    /// 启动配置
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigurationOAuth(app);
            app.MapSignalR<RequestMonitor>("/monitor");
        }
    }
}