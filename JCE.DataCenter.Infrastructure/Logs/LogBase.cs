/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs
 * 文件名：LogBase
 * 版本号：v1.0.0.0
 * 唯一标识：8a67fc89-921f-4d47-9f8f-30a025a25611
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 13:58:19
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 13:58:19
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
using JCE.Utils.Extensions;

namespace JCE.DataCenter.Infrastructure.Logs
{
    /// <summary>
    /// 日志
    /// </summary>
    public abstract class LogBase : ILog
    {

        #region 构造方法

        /// <summary>
        /// 初始化日志
        /// </summary>
        protected LogBase()
        {
            _params = new StringBuilder();
            _content = new StringBuilder();
            _sql = new StringBuilder();
            _sqlParams = new StringBuilder();
        }

        #endregion

        #region 字段

        /// <summary>
        /// 跟踪号
        /// </summary>
        protected string _traceId;
        /// <summary>
        /// 日志名称
        /// </summary>
        protected string _logName;
        /// <summary>
        /// 业务编号
        /// </summary>
        protected string _businessId;
        /// <summary>
        /// 分类
        /// </summary>
        protected string _category;
        /// <summary>
        /// 类名
        /// </summary>
        protected string _class;
        /// <summary>
        /// 方法名
        /// </summary>
        protected string _method;
        /// <summary>
        /// 参数
        /// </summary>
        protected StringBuilder _params;
        /// <summary>
        /// 标题
        /// </summary>
        protected string _caption;
        /// <summary>
        /// 内容
        /// </summary>
        protected StringBuilder _content;
        /// <summary>
        /// Sql语句
        /// </summary>
        protected StringBuilder _sql;
        /// <summary>
        /// Sql参数
        /// </summary>
        protected StringBuilder _sqlParams;
        /// <summary>
        /// 错误码
        /// </summary>
        protected string _errorCode;
        /// <summary>
        /// 异常
        /// </summary>
        protected Exception _exception;
        /// <summary>
        /// 日志级别
        /// </summary>
        protected LogLevel _level;
        /// <summary>
        /// 错误消息
        /// </summary>
        protected string _errorMessage;
        /// <summary>
        /// 堆栈跟踪
        /// </summary>
        protected string _stackTrace;

        /// <summary>
        /// 区域
        /// </summary>
        protected string _area;
        /// <summary>
        /// 控制器
        /// </summary>
        protected string _controller;
        /// <summary>
        /// 操作方法
        /// </summary>
        protected string _action;
        /// <summary>
        /// 请求方式
        /// </summary>
        protected string _requetType;

        #endregion

        #region 设置内容

        /// <summary>
        /// 设置业务编号
        /// </summary>
        /// <param name="businessId">业务编号</param>
        public ILog BusinessId(string businessId)
        {
            if (!_businessId.IsNullOrEmpty())
                _businessId += ",";
            _businessId += businessId;
            return this;
        }

        /// <summary>
        /// 设置分类
        /// </summary>
        /// <param name="category">分类</param>
        public ILog Category(string category)
        {
            _category = category;
            return this;
        }

        /// <summary>
        /// 设置类名
        /// </summary>
        /// <param name="class">类名</param>
        public ILog Class(string @class)
        {
            _class = @class;
            return this;
        }

        /// <summary>
        /// 设置方法名
        /// </summary>
        /// <param name="method">方法名</param>
        public ILog Method(string method)
        {
            _method = method;
            return this;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog Params(string value, params object[] args)
        {
            Append(_params, value, args);
            return this;
        }

        /// <summary>
        /// 追加内容
        /// </summary>
        private void Append(StringBuilder result, string value, params object[] args)
        {
            if (args == null)
                args = new object[] { string.Empty };
            if (args.Length == 0)
                result.Append(value);
            else
                result.AppendFormat(value, args);
        }

        /// <summary>
        /// 设置参数并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog ParamsLine(string value, params object[] args)
        {
            AppendLine(_params, value, args);
            return this;
        }

        /// <summary>
        /// 追加内容并换行
        /// </summary>
        private void AppendLine(StringBuilder result, string value, params object[] args)
        {
            Append(result, value, args);
            result.AppendLine();
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog Caption(string value, params object[] args)
        {
            _caption = string.Format(value, args);
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog Content(string value, params object[] args)
        {
            Append(_content, value, args);
            return this;
        }

        /// <summary>
        /// 设置内容并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog ContentLine(string value, params object[] args)
        {
            AppendLine(_content, value, args);
            return this;
        }

        /// <summary>
        /// 设置Sql语句
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog Sql(string value, params object[] args)
        {
            Append(_sql, value, args);
            return this;
        }

        /// <summary>
        /// 设置Sql语句并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog SqlLine(string value, params object[] args)
        {
            AppendLine(_sql, value, args);
            return this;
        }

        /// <summary>
        /// 设置Sql参数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog SqlParams(string value, params object[] args)
        {
            Append(_sqlParams, value, args);
            return this;
        }

        /// <summary>
        /// 设置Sql参数并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog SqlParamsLine(string value, params object[] args)
        {
            AppendLine(_sqlParams, value, args);
            return this;
        }

        /// <summary>
        /// 设置错误码
        /// </summary>
        /// <param name="value">错误码</param>
        public ILog ErrorCode(string value)
        {
            _errorCode = value;
            return this;
        }

        /// <summary>
        /// 设置异常
        /// </summary>
        /// <param name="value">异常</param>
        public ILog Exception(Exception value)
        {
            _exception = value;
            _errorMessage = value.Message;
            _stackTrace = value.StackTrace;
            return this;
        }

        /// <summary>
        /// 替换Sql语句
        /// </summary>
        /// <param name="value">值</param>
        public ILog ReplaceSql(string value)
        {
            _sql.Clear();
            _sql.Append(value);
            return this;
        }

        /// <summary>
        /// 设置Rquest
        /// </summary>
        /// <param name="area">区域</param>
        /// <param name="controller">控制器</param>
        /// <param name="action">操作方法</param>
        /// <param name="requestType">请求方式</param>
        /// <returns></returns>
        public ILog Rquest(string area = "", string controller = "", string action = "", string requestType = "")
        {
            _area = area;
            _controller = controller;
            _action = action;
            _requetType = requestType;
            return this;
        }

        #endregion

        #region 获取内容

        /// <summary>
        /// 获取标题
        /// </summary>
        public string GetCaption()
        {
            return _caption;
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        public string GetContent()
        {
            return _content.ToString();
        }

        /// <summary>
        /// 获取Sql
        /// </summary>
        public string GetSql()
        {
            return _sql.ToString();
        }

        /// <summary>
        /// Debug级别是否启用
        /// </summary>
        public virtual bool IsDebugEnabled
        {
            get { return true; }
        }

        #endregion

        #region 写日志

        /// <summary>
        /// 调试
        /// </summary>
        public void Debug()
        {
            Debug(string.Empty);
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public void Debug(string value, params object[] args)
        {
            Execute(DebugLog, LogLevel.Debug, value, args);
        }

        /// <summary>
        /// 写调试日志
        /// </summary>
        protected abstract void DebugLog();

        /// <summary>
        /// 执行
        /// </summary>
        private void Execute(Action action, LogLevel level, string value, params object[] args)
        {
            _level = level;
            Content(value, args);
            try
            {
                action();
            }
            finally
            {
                Clear();
            }
        }

        /// <summary>
        /// 清理
        /// </summary>
        protected virtual void Clear()
        {
        }

        /// <summary>
        /// 信息
        /// </summary>
        public void Info()
        {
            Info(string.Empty);
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public void Info(string value, params object[] args)
        {
            Execute(InfoLog, LogLevel.Information, value, args);
        }

        /// <summary>
        /// 写信息日志
        /// </summary>
        protected abstract void InfoLog();

        /// <summary>
        /// 警告
        /// </summary>
        public void Warn()
        {
            Warn(string.Empty);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public void Warn(string value, params object[] args)
        {
            Execute(WarnLog, LogLevel.Warning, value, args);
        }

        /// <summary>
        /// 写警告日志
        /// </summary>
        protected abstract void WarnLog();

        /// <summary>
        /// 错误
        /// </summary>
        public void Error()
        {
            Error(string.Empty);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public void Error(string value, params object[] args)
        {
            Execute(ErrorLog, LogLevel.Error, value, args);
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        protected abstract void ErrorLog();

        /// <summary>
        /// 致命错误
        /// </summary>
        public void Fatal()
        {
            Fatal(string.Empty);
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public void Fatal(string value, params object[] args)
        {
            Execute(FatalLog, LogLevel.Fatal, value, args);
        }

        /// <summary>
        /// 写致命错误日志
        /// </summary>
        protected abstract void FatalLog();

        #endregion
    }
}
