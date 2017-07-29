/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：Zyl.Domain.Config
 * 文件名：ConfigContainer
 * 版本号：v1.0.0.0
 * 唯一标识：0b0a50a4-2094-4b43-a426-6dc58465e7c3
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/13 10:03:26
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/13 10:03:26
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/

namespace JCE.DataCenter.Domain.Config
{
    /// <summary>
    /// 配置容器
    /// </summary>
    public class ConfigContainer
    {
        #region Register(注册配置)
        /// <summary>
        /// 注册配置
        /// </summary>
        public static void Register()
        {
            SysConfig.Register();            
        }
        #endregion

    }
}
