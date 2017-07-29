/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.CommonModel
 * 文件名：ResultCode
 * 版本号：v1.0.0.0
 * 唯一标识：e868fbe5-004a-40de-8775-2242d2e6064d
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/10 23:12:26
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/10 23:12:26
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

namespace JCE.DataCenter.Infrastructure.CommonModel
{
    /// <summary>
    /// 结果码
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        [Description("请求成功")]
        Success=0,

        /// <summary>
        /// 失败-业务错误
        /// </summary>
        [Description("失败")]
        Fail = 1,

        /// <summary>
        /// 找不到数据
        /// </summary>
        [Description("找不到数据")]
        NoResultFound = 2,

        /// <summary>
        /// 发生错误-系统错误
        /// </summary>
        [Description("发生错误")]
        Error = -1,

        /// <summary>
        /// 业务错误-登录超时
        /// </summary>
        [Description("登录超时")]
        LoginTimeout=40001

    }
}
