/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.WebApi.Initialize
 * 文件名：ResponseFormatterHandler
 * 版本号：v1.0.0.0
 * 唯一标识：ccfb6808-d379-4e12-b045-39a79fabc385
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/11 18:20:05
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/11 18:20:05
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
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JCE.DataCenter.Infrastructure.WebApi.Initialize
{
    /// <summary>
    /// 响应参数格式化处理器
    /// </summary>
    public class ResponseFormatterHandler
    {
        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="config">Http配置</param>
        public static void Formatter(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting=Formatting.Indented;
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";//全局处理-返回时间格式
            settings.DateTimeZoneHandling=DateTimeZoneHandling.Local;//全局处理-接收时间并做本地化处理            
            settings.ContractResolver=new CamelCasePropertyNamesContractResolver();//全局处理-变量首字母小写驼峰式命名
        }
    }
}
