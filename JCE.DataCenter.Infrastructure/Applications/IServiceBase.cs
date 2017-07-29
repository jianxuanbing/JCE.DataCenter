/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Applications
 * 文件名：IService
 * 版本号：v1.0.0.0
 * 唯一标识：7f16c4a0-e6e8-4f92-96ec-5efbbea77640
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 16:28:11
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 16:28:11
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
using Castle.Core.Logging;
using JCE.DataCenter.Infrastructure.Dependency;

namespace JCE.DataCenter.Infrastructure.Applications
{
    /// <summary>
    /// 应用服务基类接口
    /// </summary>
    public interface IServiceBase:IDependency
    {        
    }

    /// <summary>
    /// 应用服务基类接口
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    public interface IServiceBase<TDto> : IServiceBase where TDto : new()
    {
        
    }
}
