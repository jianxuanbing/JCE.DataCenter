/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.WebApi.OAuth
 * 文件名：JwtTokenFormat
 * 版本号：v1.0.0.0
 * 唯一标识：95c990ff-8ad2-43c6-951c-d9736f4f26bc
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/13 10:37:57
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/13 10:37:57
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security;
using Thinktecture.IdentityModel.Tokens;

namespace JCE.DataCenter.WebApi.OAuth
{
    /// <summary>
    /// 自定义 jwt token 格式
    /// </summary>
    public class JwtTokenFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string _issuer;
        private readonly byte[] _secret;

        /// <summary>
        /// 初始化一个<see cref="JwtTokenFormat"/>类型的实例
        /// </summary>
        /// <param name="issure">加盐</param>
        /// <param name="secret">密匙</param>
        public JwtTokenFormat(string issure, byte[] secret)
        {
            _issuer = issure;
            _secret = secret;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            var signingKey = new HmacSigningCredentials(_secret);
            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(_issuer, "Any", data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey));
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}