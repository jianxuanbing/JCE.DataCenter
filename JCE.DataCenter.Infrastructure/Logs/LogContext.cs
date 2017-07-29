/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs
 * 文件名：LogContext
 * 版本号：v1.0.0.0
 * 唯一标识：2ad213e0-2302-42ae-8793-8579bdf59b57
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 13:59:01
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 13:59:01
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.Logs
{
    /// <summary>
    /// 日志上下文
    /// </summary>
    public class LogContext
    {
        /// <summary>
        /// 初始化日志上下文
        /// </summary>
        /// <param name="traceId">跟踪号</param>
        public LogContext(string traceId)
        {
            TraceId = traceId;
        }

        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId { get; private set; }
    }
}
