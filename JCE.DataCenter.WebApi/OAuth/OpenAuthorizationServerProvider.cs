/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.WebApi.OAuth
 * 文件名：OpenAuthorizationServerProvider
 * 版本号：v1.0.0.0
 * 唯一标识：0dded8df-97c7-41ee-8cb8-14fdc8b32184
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/13 10:40:20
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/13 10:40:20
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using JCE.Utils.Extensions;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using JCE.DataCenter.Infrastructure.CommonModel;
using JCE.DataCenter.Infrastructure.Exceptions;

namespace JCE.DataCenter.WebApi.OAuth
{
    /// <summary>
    /// 开放授权服务提供者
    /// </summary>
    public class OpenAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        //grant_type=password 验证用户名以及密码，不管是受保护的还是与用户相关的API，都可以使用
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // 获取自定义参数
            //var temp = context.Request.Body;
            //temp.Seek(0, SeekOrigin.Begin);
            //byte[] bytes = new byte[temp.Length];
            //temp.Read(bytes, 0, bytes.Length);
            //string result = Encoding.UTF8.GetString(bytes);

            //允许跨域
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            if (string.IsNullOrEmpty(context.Scope[0]))
            {
                context.SetError("参数scope为必填项");
                return Task.FromResult<object>(null);
            }

            var username = context.UserName;
            var password = context.Password;
            string scope = context.Scope[0].ToLower();

            LoginInfo info;
            try
            {
                if (!OAuthCheck.CheckCredential(username, password, scope, out info))
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect");
                    //context.Rejected();
                    return Task.FromResult<object>(null);
                }
            }
            catch (BusinessException ex)
            {
                context.SetError(ex.Message);
                //context.Rejected();
                return Task.FromResult<object>(null);
            }            

            var oAuthIdentity = SetClaimsIdentity(context, username, scope, info);
            var ticket = new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties());
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }

        //验证Basic
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }


        /// <summary>
        /// 设置委托标识
        /// </summary>
        /// <param name="context"></param>
        /// <param name="username">用户名</param>
        /// <param name="scope">域类型</param>
        /// <param name="login">登录信息</param>
        /// <returns></returns>
        private static ClaimsIdentity SetClaimsIdentity(OAuthGrantResourceOwnerCredentialsContext context,
            string username, string scope,LoginInfo login)
        {
            var identity = new ClaimsIdentity("JWT");

            //identity.AddClaim(new Claim("userid", login.UserId.ToString()));
            identity.AddClaim(new Claim("username", username));
            identity.AddClaim(new Claim("scope", scope));
            identity.AddClaim(new Claim("login", login.ToJson()));

            return identity;
        }
    }
}