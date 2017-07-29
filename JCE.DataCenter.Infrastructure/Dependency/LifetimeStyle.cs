/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Dependency
 * 文件名：LifetimeStyle
 * 版本号：v1.0.0.0
 * 唯一标识：69d0c31e-6079-43aa-8aa1-b2ba4b353655
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 21:46:18
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 21:46:18
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

namespace JCE.DataCenter.Infrastructure.Dependency
{
    /// <summary>
    /// 表示依赖注入的对象声明周期
    /// </summary>
    public enum LifetimeStyle
    {
        /// <summary>
        /// 实时模式，每次获取都创建不同对象
        /// </summary>
        Transient,
        /// <summary>
        /// 局部模式，同一生命周期获得相同对象，不同生命周期获取不同对象（PerRequest）
        /// </summary>
        Scoped,
        /// <summary>
        /// 单例模式，在第一获取实例时创建，之后都获取相同对象
        /// </summary>
        Singleton
    }
}
