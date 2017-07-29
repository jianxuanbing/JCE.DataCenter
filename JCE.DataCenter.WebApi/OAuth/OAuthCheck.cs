/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.WebApi.OAuth
 * 文件名：OAuthCheck
 * 版本号：v1.0.0.0
 * 唯一标识：f02c072c-3522-444c-a179-bdb8170529a4
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/13 10:41:19
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/13 10:41:19
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JCE.Utils.Extensions;
using JCE.DataCenter.Infrastructure.CommonModel;
using JCE.DataCenter.Infrastructure.Dependency;
using JCE.DataCenter.Infrastructure.Exceptions;
using JCE.DataCenter.Services;

namespace JCE.DataCenter.WebApi.OAuth
{
    /// <summary>
    /// OAuth 验证
    /// </summary>
    public class OAuthCheck
    {
        /// <summary>
        /// 用户认证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="scope">域</param>
        /// <param name="info">登录信息</param>
        /// <returns></returns>
        public static bool CheckCredential(string username, string password, string scope,out LoginInfo info)
        {
            //LoginAct act=new LoginAct() {UserName = username,Password = password};
            info = null;
            //switch (scope)
            //{
            //    case "pc":
            //        return GetLoginInfo(act, out info, LoginRoleType.Normal);
            //    case "admin":
            //        return GetLoginInfo(act, out info, LoginRoleType.Admin);
            //    case "counter":
            //        return GetLoginInfo(act, out info, LoginRoleType.Cashier);
            //}
            return false;
        }

        //private static bool GetLoginInfo(LoginAct act, out LoginInfo info,LoginRoleType roleType)
        //{
        //    var loginService = Ioc.Create<IAccountService>();
        //    var success = false;
        //    info = null;
        //    switch (roleType)
        //    {
        //        case LoginRoleType.Normal:
        //            info = loginService.UserLogin(act);
        //            break;
        //        case LoginRoleType.Admin:
        //            info = loginService.MerchantLogin(act);
        //            break;
        //        case LoginRoleType.Cashier:
        //            throw new BusinessException("暂未实现柜台登录");
        //    }
        //    if (!info.IsNull())
        //    {
        //        success = true;
        //    }            
        //    return success;
        //}       

        /// <summary>
        /// 获取来源地址
        /// </summary>
        /// <returns></returns>
        private static string GetSourceUrl()
        {
            return HttpContext.Current.Request.UrlReferrer == null
                ? null
                : HttpContext.Current.Request.UrlReferrer.Host.ToString();
        }
    }
}