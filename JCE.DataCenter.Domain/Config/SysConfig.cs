/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：Zyl.Domain.Config
 * 文件名：SysConfig
 * 版本号：v1.0.0.0
 * 唯一标识：f6d65727-5ad5-4595-bd20-0a7ef4f3f442
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/13 10:01:25
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/13 10:01:25
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/

using System;
using JCE.Utils.Common;
using JCE.Utils.Extensions;

namespace JCE.DataCenter.Domain.Config
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class SysConfig
    {
        #region Property(属性)
        /// <summary>
        /// 商家ID
        /// </summary>
        public static Guid MerchantId { get; private set; }
        /// <summary>
        /// Jwt 加盐
        /// </summary>
        public static string Issuer { get; private set; }

        /// <summary>
        /// Jwt 密匙
        /// </summary>
        public static string Secret { get; private set; }

        /// <summary>
        /// Api Token 地址
        /// </summary>
        public static string ApiTokenUrl { get; private set; }

        /// <summary>
        /// 发送验证码 接口
        /// </summary>
        public static string SendVerifyCode { get; private set; }
        #endregion

        #region Register(注册系统配置)
        /// <summary>
        /// 注册系统配置
        /// </summary>
        internal static void Register()
        {
            MerchantId = ConfigUtil.GetAppSettings("merchantId").ToGuid();
            Issuer = ConfigUtil.GetAppSettings("issuer");
            Secret = ConfigUtil.GetAppSettings("secret");
            ApiTokenUrl = ConfigUtil.GetAppSettings("ApiTokenUrl");

            SendVerifyCode = ConfigUtil.GetAppSettings("SendVerifyCode");
        }
        #endregion

    }
}
