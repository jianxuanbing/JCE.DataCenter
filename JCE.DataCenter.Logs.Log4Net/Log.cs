/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Logs.Log4Net
 * 文件名：Log
 * 版本号：v1.0.0.0
 * 唯一标识：088523c7-4a9e-4af9-ae48-d44938cc01fb
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 14:01:47
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 14:01:47
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
using System.Web;
using JCE.Utils.Common;
using JCE.Utils.Extensions;
using JCE.Utils.Webs;
using JCE.DataCenter.Infrastructure;
using JCE.DataCenter.Infrastructure.Logs;

namespace JCE.DataCenter.Logs.Log4Net
{
    /// <summary>
    /// 日志
    /// </summary>
    public class Log : LogBase
    {
        /// <summary>
        /// log4net日志接口
        /// </summary>
        private readonly log4net.ILog _log;

        /// <summary>
        /// 初始化一个<see cref="Log"/>类型的实例
        /// </summary>
        /// <param name="log">Log4Net日志组件</param>
        /// <param name="traceId">跟踪号</param>
        private Log(log4net.ILog log,string traceId)
        {
            _log = log;
            _logName = log.Logger.Name;
            _traceId = traceId;
        }

        #region 工厂方法

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <returns></returns>
        public static ILog GetLog()
        {
            return GetLog(string.Empty);
        }

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="instance">实例</param>
        /// <returns></returns>
        public static ILog GetLog(object instance)
        {
            if (instance == null)
            {
                return GetLog();
            }
            var className = instance.GetType().ToString();
            return GetLog(className).Class(className);
        }

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="logName">日志名</param>
        /// <returns></returns>
        public static ILog GetLog(string logName)
        {
            LogContext logContext = GetLogContext();
            return new Log(log4net.LogManager.GetLogger(logName),logContext.TraceId);
        }

        /// <summary>
        /// 获取日志上下文
        /// </summary>
        /// <returns></returns>
        private static LogContext GetLogContext()
        {
            string key = "WeiHai.Infrastructure.Logs.LogContext";
            var result = Context.Get<LogContext>(key);
            if (result != null)
            {
                return result;
            }
            result = CreateLogContext();
            Context.Add(key, result);
            return result;
        }

        /// <summary>
        /// 创建日志上下文
        /// </summary>
        /// <returns></returns>
        private static LogContext CreateLogContext()
        {
            return new LogContext(Guid.NewGuid().ToString());
        }
        #endregion

        /// <summary>
        /// 写调试日志
        /// </summary>
        protected override void DebugLog()
        {
            _log.Debug(GetMessage());
        }

        /// <summary>
        /// 获取日志消息
        /// </summary>
        /// <returns></returns>
        private LogMessage GetMessage()
        {
            return new LogMessage()
            {
                LogName = _logName,
                Level = _level.Description(),
                TraceId = _traceId,
                OperationTime = DateTime.Now.ToMillisecondString(),
                Url = GetUrl(),
                BusinessId = _businessId,
                Application = GetApplication(),
                Tenant = GetTenant(),
                Category = _category,
                Class = _class,
                Method = _method,
                Params = _params.ToString(),
                IP = GetIp(),
                Host = GetHost(),
                Browser = GetBrowser(),
                ThreadId = ThreadUtil.ThreadId,
                Caption = _caption,
                Content = _content.ToString(),
                Sql = _sql.ToString(),
                SqlParams = _sqlParams.ToString(),
                ErrorCode = _errorCode,
                Error = _errorMessage,
                StackTrace = _stackTrace,
                Area = _area,
                Controller = _controller,
                Action = _action,
                RequestType = _requetType,
            };
        }

        /// <summary>
        /// 获取Url
        /// </summary>
        /// <returns></returns>
        private string GetUrl()
        {
            if (HttpContext.Current == null)
            {
                return string.Empty;
            }
            try
            {
                return HttpContext.Current.Request.Url.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取应用程序
        /// </summary>
        /// <returns></returns>
        private string GetApplication()
        {
            return "";
        }

        /// <summary>
        /// 获取租户
        /// </summary>
        /// <returns></returns>
        private string GetTenant()
        {
            return "";
        }

        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        private string GetIp()
        {
            try
            {
                return NetUtil.Ip;
            }
            catch
            {

                return string.Empty;
            }
        }

        /// <summary>
        /// 获取主机
        /// </summary>
        /// <returns></returns>
        private string GetHost()
        {
            try
            {
                return NetUtil.Host;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取浏览器
        /// </summary>
        /// <returns></returns>
        private string GetBrowser()
        {
            try
            {
                return NetUtil.Browser;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 清理
        /// </summary>
        protected override void Clear()
        {
            _businessId = null;
            _category = null;
            _class = null;
            _method = null;
            _params = new StringBuilder();
            _caption = null;
            _content = new StringBuilder();
            _sql = new StringBuilder();
            _sqlParams = new StringBuilder();
            _errorCode = null;
            _exception = null;
            _errorMessage = null;
            _stackTrace = null;
            _area = null;
            _controller = null;
            _action = null;
            _requetType = null;
        }

        /// <summary>
        /// 写信息日志
        /// </summary>
        protected override void InfoLog()
        {
            _log.Info(GetMessage());
        }

        /// <summary>
        /// 写警告日志
        /// </summary>
        protected override void WarnLog()
        {
            _log.Warn(GetMessage());
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        protected override void ErrorLog()
        {
            _log.Error(GetMessage());
        }

        /// <summary>
        /// 写致命错误日志
        /// </summary>
        protected override void FatalLog()
        {
            _log.Fatal(GetMessage());
        }
    }
}
