/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.SqlBuilder.Where
 * 文件名：DynamicPropertyModel
 * 版本号：v1.0.0.0
 * 唯一标识：0a9a14f1-f9fc-463f-87e1-c3dceb49a09e
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 9:59:43
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 9:59:43
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

namespace JCE.DataCenter.Infrastructure.SqlBuilder.Where
{
    /// <summary>
    /// 动态属性对象，动态生成类的属性
    /// </summary>
    public class DynamicPropertyModel
    {
        /// <summary>
        /// 属性名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 属性类型
        /// </summary>
        public Type PropertyType { get; set; }
    }
}
