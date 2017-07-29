using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using JCE.DataCenter.Domain.Config;
using JCE.DataCenter.WebApi.OAuth;

namespace JCE.DataCenter.WebApi
{
    public partial class Startup
    {
        public void ConfigurationOAuth(IAppBuilder app)
        {
            var issuer = SysConfig.Issuer;
            var secret =
                TextEncodings.Base64Url.Decode(Convert.ToBase64String(Encoding.Default.GetBytes(SysConfig.Secret)));

            //使用jwt进行身份认证
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions()
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] {"Any"},
                IssuerSecurityTokenProviders =
                    new IIssuerSecurityTokenProvider[] {new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret),}
            });

            var oauthOptions=new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),//获取 access_token 授权服务请求地址
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(6),//access_token 过期时间
                Provider = new OpenAuthorizationServerProvider(),//access_token 相关授权服务
                AccessTokenFormat = new JwtTokenFormat(issuer, secret),//自定义token信息格式
                RefreshTokenProvider = new JwtRefreshTokenProvider(),//刷新令牌 相关授权服务
            };

            app.UseOAuthAuthorizationServer(oauthOptions);
        }
    }
}