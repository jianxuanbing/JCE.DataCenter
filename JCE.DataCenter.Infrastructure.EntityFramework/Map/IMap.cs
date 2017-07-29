/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework
 * 文件名：IMap
 * 版本号：v1.0.0.0
 * 唯一标识：baf44e3c-49ee-461a-ae8b-b276d5acc5f9
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 14:23:41
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 14:23:41
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/

using System.Data.Entity.ModelConfiguration.Configuration;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Map
{
    /// <summary>
    /// 映射
    /// </summary>
    public interface IMap
    {
        /// <summary>
        /// 将配置添加到管理器
        /// </summary>
        /// <param name="registrar">配置管理器</param>
        void AddTo(ConfigurationRegistrar registrar);
    }
}
