/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Exceptions
 * 文件名：BusinessExceptionExtensions
 * 版本号：v1.0.0.0
 * 唯一标识：e6ae2b3d-b648-4d35-8a25-d9335da5783a
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 16:57:33
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 16:57:33
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

namespace JCE.DataCenter.Infrastructure.Exceptions
{
    /// <summary>
    /// 业务异常 扩展
    /// </summary>
    public static class BusinessExceptionExtensions
    {
        /// <summary>
        /// 验证业务，满足条件则抛出业务异常
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="condition">业务条件</param>
        /// <param name="msg">业务异常消息</param>
        [Obsolete]
        public static void ValidBusiness(this object value, bool condition,string msg)
        {
            if (condition)
            {
                throw new BusinessException(msg);
            }
        }        

        /// <summary>
        /// 验证业务，满足条件则抛出业务异常
        /// </summary>
        /// <param name="condition">业务条件</param>
        /// <param name="msg">业务异常消息</param>
        public static void ValidBusiness(this bool condition, string msg)
        {
            if (condition)
            {
                throw new BusinessException(msg);
            }
        }

        /// <summary>
        /// 验证业务，满足条件则抛出业务异常
        /// </summary>
        /// <param name="condition">业务条件</param>
        /// <param name="msg">业务异常消息</param>
        /// <param name="code">错误码</param>
        public static void ValidBusiness(this bool condition, string msg, int code)
        {
            if (condition)
            {
                throw new BusinessException(msg,code);
            }
        }
    }
}
