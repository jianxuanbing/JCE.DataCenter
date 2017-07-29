/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Services
 * 文件名：ApplicationServiceBase
 * 版本号：v1.0.0.0
 * 唯一标识：422d63eb-5483-40fc-9d33-e393badb3569
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/13 9:48:09
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/13 9:48:09
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JCE.Utils.Extensions;
using JCE.DataCenter.Infrastructure.Applications;
using JCE.DataCenter.Infrastructure.Caching;
using JCE.DataCenter.Infrastructure.CommonModel;
using JCE.DataCenter.Infrastructure.Exceptions;
using JCE.DataCenter.Infrastructure.Logs;
using JCE.DataCenter.Logs.Log4Net;

namespace JCE.DataCenter.Services
{
    /// <summary>
    /// 应用服务基类
    /// </summary>
    public class ApplicationServiceBase:ServiceBase
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        protected ILog Logger = Log.GetLog(typeof(ApplicationServiceBase));

        /// <summary>
        /// 缓存器
        /// </summary>
        protected ICache Cacher = CacheManager.GetCacher(typeof(ApplicationServiceBase));

        /// <summary>
        /// 当前登录信息
        /// </summary>
        private LoginInfo _current;

        /// <summary>
        /// 当前登录信息
        /// </summary>
        protected LoginInfo Current
        {
            get
            {
                if (_current == null)
                {
                    var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                    var loginInfo = identity.Claims.Where(x => x.Type == "login").Select(x => x.Value).FirstOrDefault();
                    _current = loginInfo.ToObject<LoginInfo>();
                }
                return _current;
            }
        }

        /// <summary>
        /// 验证业务，满足条件则抛出业务异常
        /// </summary>
        /// <param name="condition">业务条件</param>
        /// <param name="msg">业务异常消息</param>
        protected void ValidBusiness(bool condition, string msg)
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
        protected void ValidBusiness(bool condition, string msg,int code)
        {
            if (condition)
            {
                throw new BusinessException(msg,code);
            }
        }
    }
}
