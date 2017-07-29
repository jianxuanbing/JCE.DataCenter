/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.WebApi.SignalR
 * 文件名：SignalRLoggingRepository
 * 版本号：v1.0.0.0
 * 唯一标识：1b17afc0-a1a4-48a8-bce0-132a5f2f358f
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/24 9:00:35
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/24 9:00:35
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JCE.Utils.Extensions;
using Microsoft.AspNet.SignalR;
using JCE.DataCenter.Infrastructure.WebApi.Logging;

namespace JCE.DataCenter.WebApi.SignalR
{
    /// <summary>
    /// SignalR记录仓储
    /// </summary>
    public class SignalRLoggingRepository : ILoggingRepository
    {
        /// <summary>
        /// 连接上下文
        /// </summary>
        private static IPersistentConnectionContext _connectionContext =
            GlobalHost.ConnectionManager.GetConnectionContext<RequestMonitor>();

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="loggingInfo">api日志信息</param>
        public void Log(ApiLoggingInfo loggingInfo)
        {
            _connectionContext.Connection.Broadcast(loggingInfo.ToJson());
        }
    }
}