/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.CommonModel
 * 文件名：ApiResult
 * 版本号：v1.0.0.0
 * 唯一标识：55fc4b22-c82c-4461-8d86-385fae2041d0
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/10 23:18:55
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/10 23:18:55
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

namespace JCE.DataCenter.Infrastructure.CommonModel
{
    /// <summary>
    /// Api请求数据结果
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 全局返回码
        /// </summary>
        public ResultCode Code { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }

        

        /// <summary>
        /// 初始化一个<see cref="ApiResult"/>类型的实例
        /// </summary>
        public ApiResult()
        {
            OperationTime=DateTime.Now;
        }
    }

    /// <summary>
    /// Api请求数据结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T> : ApiResult
    {
        /// <summary>
        /// 数据结果
        /// </summary>
        public T Data { get; set; }

       
    }
}
