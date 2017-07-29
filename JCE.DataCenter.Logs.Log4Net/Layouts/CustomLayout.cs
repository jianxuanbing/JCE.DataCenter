/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：Zyl.Logs.Log4Net.Layouts
 * 文件名：CustomLayout
 * 版本号：v1.0.0.0
 * 唯一标识：88d676a9-e476-48bf-ae53-4df84eeb2501
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 14:02:00
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 14:02:00
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/

using log4net.Layout;

namespace JCE.DataCenter.Logs.Log4Net.Layouts
{
    /// <summary>
    /// 自定义log4net布局组件
    /// </summary>
    public class CustomLayout : PatternLayout
    {
        public CustomLayout()
        {
            AddConverter("property", typeof(CustomPatternLayoutConverter));
        }
    }
}
