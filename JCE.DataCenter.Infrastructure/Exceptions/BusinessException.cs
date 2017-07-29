/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Exceptions
 * 文件名：BusinessException
 * 版本号：v1.0.0.0
 * 唯一标识：69ec41a6-051b-4223-9417-9ad94f1334b2
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/10 23:10:54
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/10 23:10:54
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
using JCE.DataCenter.Infrastructure.CommonModel;

namespace JCE.DataCenter.Infrastructure.Exceptions
{
    /// <summary>
    /// 业务异常
    /// </summary>
    public class BusinessException:Exception
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrorCode { get; set; }

        #region Constructor(构造函数)
        /// <summary>
        /// 初始化一个<see cref="BusinessException"/>类型的实例
        /// </summary>
        /// <param name="message">错误消息</param>
        public BusinessException(string message) : this(message, (int)ResultCode.Error)
        {
        }

        /// <summary>
        /// 初始化一个<see cref="BusinessException"/>类型的实例
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="errCode">错误码</param>
        public BusinessException(string message, int errCode) : base(message)
        {
            this.ErrorCode = errCode;
        }
        #endregion

    }
}
