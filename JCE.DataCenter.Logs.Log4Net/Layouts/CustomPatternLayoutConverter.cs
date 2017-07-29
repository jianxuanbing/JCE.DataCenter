/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：Zyl.Logs.Log4Net.Layouts
 * 文件名：CustomPatternLayoutConverter
 * 版本号：v1.0.0.0
 * 唯一标识：94de3746-6729-4f72-ba45-52e509b22450
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/14 14:02:15
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/14 14:02:15
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/

using System.IO;
using System.Reflection;
using log4net.Core;
using log4net.Layout.Pattern;

namespace JCE.DataCenter.Logs.Log4Net.Layouts
{
    /// <summary>
    /// 自定义log4net布局转换组件
    /// </summary>
    public class CustomPatternLayoutConverter : PatternLayoutConverter
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="writer">文本写入器</param>
        /// <param name="loggingEvent">日志事件</param>
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            if (Option == null)
            {
                WriteDictionary(writer, loggingEvent.Repository, loggingEvent.GetProperties());
            }
            else
            {
                WriteObject(writer, loggingEvent.Repository, LookupProperty(Option, loggingEvent));
            }
        }

        /// <summary>
        /// 查找日志对象的属性值
        /// </summary>
        /// <param name="property">属性</param>
        /// <param name="loggingEvent">日志事件</param>
        /// <returns></returns>
        private object LookupProperty(string property, LoggingEvent loggingEvent)
        {
            object propertyValue = string.Empty;
            PropertyInfo propertyInfo = loggingEvent.MessageObject.GetType().GetProperty(property);
            if (propertyInfo != null)
            {
                propertyValue = propertyInfo.GetValue(loggingEvent.MessageObject, null);
            }
            return propertyValue;
        }
    }
}
