/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Logs
 * 文件名：EfLog
 * 版本号：v1.0.0.0
 * 唯一标识：578e6241-d0dc-42f3-95ec-310eccb15295
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 15:54:38
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 15:54:38
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JCE.Utils;
using JCE.Utils.Extensions;
using JCE.DataCenter.Infrastructure.Logs;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Logs
{
    /// <summary>
    /// EF日志
    /// </summary>
    public class EfLog
    {
        /// <summary>
        /// 跟踪号
        /// </summary>
        private readonly string _traceId;

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Logger { get; private set; }

        /// <summary>
        /// 初始化一个<see cref="EfLog"/>类型的实例
        /// </summary>
        /// <param name="traceId">跟踪号</param>
        /// <param name="log">日志</param>
        public EfLog(string traceId, ILog log)
        {
            _traceId = traceId;
            Logger = log;
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log">sql日志</param>
        public void Write(string log)
        {
            if (!Logger.IsDebugEnabled)
            {
                return;
            }
            if (log.IsEmpty())
            {
                return;
            }
            AddLog(log);
            log = FilterLog(log);
            if (IsSql(log))
            {
                AddSql(log);
                return;
            }
            if (IsParam(log))
            {
                ReplaceParam(log);
                return;
            }
            if (IsClose(log))
            {
                Logger.Caption("Ef执行日志，工作单元标识:{0}", _traceId);
                Logger.Debug();
            }
        }

        /// <summary>
        /// 过滤日志
        /// </summary>
        /// <param name="log">日志</param>
        /// <returns></returns>
        public static string FilterLog(string log)
        {
            return log.Replace("\r", "").Replace("\n", "");
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="log">日志</param>
        private void AddLog(string log)
        {
            log = log.Trim();
            if (!IsSql(log))
            {
                log = log.Replace(Sys.Line, " ");
            }
            Logger.ContentLine(log);
        }

        /// <summary>
        /// 是否Sql语句
        /// </summary>
        /// <param name="log">日志</param>
        /// <returns></returns>
        private bool IsSql(string log)
        {
            const string pattern =
                "打开了连接|关闭了连接|启动了事务|提交了事务|^Started transaction|^Committed transaction|^Opened connection|^Closed connection|^--";
            return !Regex.IsMatch(log, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        /// 添加Sql
        /// </summary>
        /// <param name="log">日志</param>
        private void AddSql(string log)
        {
            Logger.SqlLine(log);
        }

        /// <summary>
        /// 是否参数
        /// </summary>
        /// <param name="log">日志</param>
        /// <returns></returns>
        public static bool IsParam(string log)
        {
            if (log.Length > 200)
            {
                return false;
            }
            const string pattern = @"--\s.*:\s'?.*'?\s\(Type";
            return Regex.IsMatch(log, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        /// 替换sql中的参数
        /// </summary>
        /// <param name="value">值</param>
        private void ReplaceParam(string value)
        {
            var param = ResolveParam(value);
            var paramName = string.Format(@"(@|:|\?)?{0}(?=[^\d])", param.Item1);
            var sql = Regex.Replace(Logger.GetSql(), paramName, param.Item2);
            Logger.ReplaceSql(sql);
        }

        /// <summary>
        /// 是否关闭连接
        /// </summary>
        /// <param name="log">日志</param>
        /// <returns></returns>
        private bool IsClose(string log)
        {
            const string pattern = "关闭了连接|^Closed connection";
            return Regex.IsMatch(log, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        /// 从sql日志中解析出参数名和参数值
        /// </summary>
        /// <param name="log">sql日志</param>
        /// <returns></returns>
        public static Tuple<string, string> ResolveParam(string log)
        {
            string pattern = @"--\s(.*):\s('?.*'?)\s\(Type";
            var match = Regex.Match(log, pattern, RegexOptions.IgnoreCase);
            return new Tuple<string, string>(match.Result("$1"), FilterValue(match.Result("$2")));
        }

        /// <summary>
        /// 过滤值得引号
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        private static string FilterValue(string value)
        {
            if (value == "'null'")
            {
                return "null";
            }
            return value;
        }
    }
}
