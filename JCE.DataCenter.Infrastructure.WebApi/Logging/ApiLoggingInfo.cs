/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Logging
 * 文件名：ApiLoggingInfo
 * 版本号：v1.0.0.0
 * 唯一标识：06fcb831-8965-485d-bfc6-048415d18549
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/23 18:30:24
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/23 18:30:24
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.WebApi.Logging
{
    /// <summary>
    /// API日志信息
    /// </summary>    
    public class ApiLoggingInfo
    {
        private readonly List<string> _headers=new List<string>();

        /// <summary>
        /// 请求头
        /// </summary>
        public List<string> Headers
        {
            get { return _headers; }
        }

        /// <summary>
        /// 请求方法
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string UriAccessed { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string BodyContent { get; set; }

        /// <summary>
        /// 响应状态码
        /// </summary>
        public HttpStatusCode ResponseStatusCode { get; set; }

        /// <summary>
        /// 响应状态消息
        /// </summary>
        public string ResponseStatusMessage { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 请求开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 请求结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 总时间
        /// </summary>
        public double TotalTime { get; set; }

        /// <summary>
        /// 日志输出级别
        /// </summary>
        public LoggingLevel LoggingLevel { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime ActionTime { get; set; }


        public ApiLoggingInfo()
        {
            ActionTime=DateTime.Now;
        }
    }
}
