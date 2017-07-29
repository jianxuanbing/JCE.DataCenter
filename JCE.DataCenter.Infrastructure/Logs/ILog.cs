/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Logs
 * 文件名：ILog
 * 版本号：v1.0.0.0
 * 唯一标识：30fc587b-5efa-4848-a6a2-c63dbb788131
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 13:57:56
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 13:57:56
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
    /// 日志操作
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 设置业务编号
        /// </summary>
        /// <param name="businessId">业务编号</param>
        ILog BusinessId(string businessId);

        /// <summary>
        /// 设置分类
        /// </summary>
        /// <param name="category">分类</param>
        ILog Category(string category);

        /// <summary>
        /// 设置类名
        /// </summary>
        /// <param name="class">类名</param>
        ILog Class(string @class);

        /// <summary>
        /// 设置方法名
        /// </summary>
        /// <param name="method">方法名</param>
        ILog Method(string method);

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        ILog Params(string value, params object[] args);

        /// <summary>
        /// 设置参数并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        ILog ParamsLine(string value, params object[] args);

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        ILog Caption(string value, params object[] args);

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        ILog Content(string value, params object[] args);

        /// <summary>
        /// 设置内容并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        ILog ContentLine(string value, params object[] args);

        /// <summary>
        /// 设置Sql语句
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        ILog Sql(string value, params object[] args);

        /// <summary>
        /// 设置Sql语句并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        ILog SqlLine(string value, params object[] args);

        /// <summary>
        /// 设置Sql参数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        ILog SqlParams(string value, params object[] args);

        /// <summary>
        /// 设置Sql参数并换行
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        ILog SqlParamsLine(string value, params object[] args);

        /// <summary>
        /// 设置错误码
        /// </summary>
        /// <param name="value">错误码</param>
        ILog ErrorCode(string value);

        /// <summary>
        /// 设置异常
        /// </summary>
        /// <param name="value">异常</param>
        ILog Exception(Exception value);

        /// <summary>
        /// 替换Sql语句
        /// </summary>
        /// <param name="value">值</param>
        ILog ReplaceSql(string value);

        /// <summary>
        /// 设置Rquest
        /// </summary>
        /// <param name="area">区域</param>
        /// <param name="controller">控制器</param>
        /// <param name="action">操作方法</param>
        /// <param name="requestType">请求方式</param>
        /// <returns></returns>
        ILog Rquest(string area="", string controller="", string action="",string requestType="");

        /// <summary>
        /// 获取标题
        /// </summary>
        string GetCaption();

        /// <summary>
        /// 获取内容
        /// </summary>
        string GetContent();

        /// <summary>
        /// 获取Sql
        /// </summary>
        string GetSql();

        /// <summary>
        /// Debug级别是否启用
        /// </summary>
        bool IsDebugEnabled { get; }

        /// <summary>
        /// 调试
        /// </summary>
        void Debug();

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        void Debug(string value, params object[] args);

        /// <summary>
        /// 信息
        /// </summary>
        void Info();

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        void Info(string value, params object[] args);

        /// <summary>
        /// 警告
        /// </summary>
        void Warn();

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        void Warn(string value, params object[] args);

        /// <summary>
        /// 错误
        /// </summary>
        void Error();

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        void Error(string value, params object[] args);

        /// <summary>
        /// 致命错误
        /// </summary>
        void Fatal();

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="args">变量值</param>
        void Fatal(string value, params object[] args);

    }
}
