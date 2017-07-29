/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Filters
 * 文件名：IgnoreResultHandleAttribute
 * 版本号：v1.0.0.0
 * 唯一标识：7d1d53ff-e997-4adf-b1da-6bbfb41ab81c
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 18:12:43
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 18:12:43
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

namespace JCE.DataCenter.Infrastructure.WebApi.Filters
{
    /// <summary>
    /// 忽略返回结果处理-属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,Inherited = false)]
    public class IgnoreResultHandleAttribute:Attribute
    {
    }
}
