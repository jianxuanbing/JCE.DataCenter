/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Data.Uow
 * 文件名：IUnitOfWork
 * 版本号：v1.0.0.0
 * 唯一标识：df25d4b7-723e-43e1-8d8a-d3c1192af043
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 9:28:31
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 9:28:31
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/

using System;

namespace JCE.DataCenter.Infrastructure.Domain.Uow
{
    /// <summary>
    /// 业务工作单元接口
    /// </summary>
    public interface IUnitOfWork:IDisposable
    {
        /// <summary>
        /// 启动
        /// </summary>
        void Start();

        /// <summary>
        /// 提交更新
        /// </summary>
        void Commit();
    }
}
