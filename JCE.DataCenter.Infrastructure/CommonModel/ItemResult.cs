/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.CommonModel
 * 文件名：ItemResult
 * 版本号：v1.0.0.0
 * 唯一标识：f35af2ef-9332-4aab-8aff-fc7ef5beeeca
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/18 17:35:01
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/18 17:35:01
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
    /// 列表项结果-下拉列表
    /// </summary>
    public class ItemResult
    {
        #region Property(属性)
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int SortId { get; set; }
        #endregion
    }
}
