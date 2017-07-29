/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs
 * 文件名：NullLog
 * 版本号：v1.0.0.0
 * 唯一标识：1e5e5539-47ce-4d2e-b1d5-00dc1f80e673
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 14:00:15
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 14:00:15
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
    /// 空日志
    /// </summary>
    public class NullLog : ILog
    {
        /// <summary>
        /// 初始化日志
        /// </summary>
        private NullLog()
        {
        }

        /// <summary>
        /// 空日志实例
        /// </summary>
        public static readonly NullLog Instance = new NullLog();

        /// <summary>
        /// 设置业务编号
        /// </summary>
        /// <param name="businessId">业务编号</param>
        public ILog BusinessId(string businessId)
        {
            return this;
        }

        /// <summary>
        /// 设置分类
        /// </summary>
        /// <param name="category">分类</param>
        public ILog Category(string category)
        {
            return this;
        }

        /// <summary>
        /// 设置类名
        /// </summary>
        /// <param name="class">类名</param>
        public ILog Class(string @class)
        {
            return this;
        }

        /// <summary>
        /// 设置方法名
        /// </summary>
        /// <param name="method">方法名</param>
        public ILog Method(string method)
        {
            return this;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog Params(string value, params object[] args)
        {
            return this;
        }

        /// <summary>
        /// 设置参数并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog ParamsLine(string value, params object[] args)
        {
            return this;
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog Caption(string value, params object[] args)
        {
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog Content(string value, params object[] args)
        {
            return this;
        }

        /// <summary>
        /// 设置内容并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog ContentLine(string value, params object[] args)
        {
            return this;
        }

        /// <summary>
        /// 设置Sql语句
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog Sql(string value, params object[] args)
        {
            return this;
        }

        /// <summary>
        /// 设置Sql语句并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog SqlLine(string value, params object[] args)
        {
            return this;
        }

        /// <summary>
        /// 设置Sql参数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog SqlParams(string value, params object[] args)
        {
            return this;
        }

        /// <summary>
        /// 设置Sql参数并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public ILog SqlParamsLine(string value, params object[] args)
        {
            return this;
        }

        /// <summary>
        /// 设置错误码
        /// </summary>
        /// <param name="value">错误码</param>
        public ILog ErrorCode(string value)
        {
            return this;
        }

        /// <summary>
        /// 设置异常
        /// </summary>
        /// <param name="value">异常</param>
        public ILog Exception(Exception value)
        {
            return this;
        }

        /// <summary>
        /// 替换Sql语句
        /// </summary>
        /// <param name="value">值</param>
        public ILog ReplaceSql(string value)
        {
            return this;
        }

        public ILog Rquest(string area = "", string controller = "", string action = "", string requestType = "")
        {
            return this;
        }

        /// <summary>
        /// 获取标题
        /// </summary>
        public string GetCaption()
        {
            return string.Empty;
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        public string GetContent()
        {
            return string.Empty;
        }

        /// <summary>
        /// 获取Sql
        /// </summary>
        public string GetSql()
        {
            return string.Empty;
        }

        /// <summary>
        /// Debug级别是否启用
        /// </summary>
        public bool IsDebugEnabled
        {
            get { return false; }
        }

        /// <summary>
        /// 调试
        /// </summary>
        public void Debug()
        {
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public void Debug(string value, params object[] args)
        {
        }

        /// <summary>
        /// 信息
        /// </summary>
        public void Info()
        {
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public void Info(string value, params object[] args)
        {
        }

        /// <summary>
        /// 警告
        /// </summary>
        public void Warn()
        {
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public void Warn(string value, params object[] args)
        {
        }

        /// <summary>
        /// 错误
        /// </summary>
        public void Error()
        {
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public void Error(string value, params object[] args)
        {
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        public void Fatal()
        {
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        public void Fatal(string value, params object[] args)
        {
        }
    }
}
