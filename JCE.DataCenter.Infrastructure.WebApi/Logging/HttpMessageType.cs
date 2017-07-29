/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Logging
 * 文件名：HttpMessageType
 * 版本号：v1.0.0.0
 * 唯一标识：e114833f-74e5-41cd-a59d-a115d6fbe279
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/23 18:38:39
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/23 18:38:39
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.WebApi.Logging
{
    /// <summary>
    /// Http消息类型
    /// </summary>
    public enum HttpMessageType
    {
        /// <summary>
        /// 请求
        /// </summary>
        [Description("请求")]
        Request,
        /// <summary>
        /// 响应
        /// </summary>
        [Description("响应")]
        Response,
    }
}
