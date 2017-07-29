/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.SqlBuilder.Where
 * 文件名：FieldInfo
 * 版本号：v1.0.0.0
 * 唯一标识：e9362414-750f-483e-b063-92131fd7e8ed
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 9:03:10
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 9:03:10
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
    /// 字段信息
    /// </summary>
    internal class WhereInfo
    {
        #region Property(属性)
        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 字段值，开始字段值
        /// </summary>
        public object FieldValue { get; set; }

        /// <summary>
        /// 字段值，结束字段值（仅Between）
        /// </summary>
        public object EndValue { get; set; }

        /// <summary>
        /// 字段值类型
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Sql操作符
        /// </summary>
        public SqlOperator SqlOperator { get; set; }

        /// <summary>
        /// 拼接条件
        /// </summary>
        public bool Condition { get; set; }
        
        /// <summary>
        /// Sql条件，如果当前条件存在，则忽略其他设置
        /// </summary>
        public string SqlWhere { get; set; }
        #endregion

        #region Constructor(构造函数)
        /// <summary>
        /// 初始化一个<see cref="WhereInfo"/>类型的实例
        /// </summary>
        /// <param name="sqlWhere">sql语句条件</param>
        public WhereInfo(string sqlWhere) : this(sqlWhere, true)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="WhereInfo"/>类型的实例
        /// </summary>
        /// <param name="sqlWhere">sql语句条件</param>
        /// <param name="condition">拼接条件</param>
        public WhereInfo(string sqlWhere, bool condition)
        {
            SqlWhere = sqlWhere;
            Condition = condition;
        }
        /// <summary>
        /// 初始化一个<see cref="WhereInfo"/>类型的实例
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">操作符</param>
        public WhereInfo(string fieldName, object fieldValue, SqlOperator sqlOperator):this(fieldName,fieldValue,sqlOperator,true)
        {            
        }
        /// <summary>
        /// 初始化一个<see cref="WhereInfo"/>类型的实例
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="sqlOperator">操作符</param>
        /// <param name="condition">拼接条件</param>
        public WhereInfo(string fieldName, object fieldValue, SqlOperator sqlOperator, bool condition)
        {
            FieldName = fieldName;
            Type = fieldValue.GetType();
            SqlOperator = sqlOperator;
            Condition = condition;
            FieldValue = fieldValue;
        }
        /// <summary>
        /// 初始化一个<see cref="WhereInfo"/>类型的实例
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="beginValue">开始字段值</param>
        /// <param name="endValue">结束字段值</param>
        /// <param name="sqlOperator">操作符</param>
        public WhereInfo(string fieldName, object beginValue, object endValue, SqlOperator sqlOperator):this(fieldName,beginValue,endValue,sqlOperator,true)
        {            
        }
        /// <summary>
        /// 初始化一个<see cref="WhereInfo"/>类型的实例
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="beginValue">开始字段值</param>
        /// <param name="endValue">结束字段值</param>
        /// <param name="sqlOperator">操作符</param>
        /// <param name="condition">拼接条件</param>
        public WhereInfo(string fieldName, object beginValue, object endValue, SqlOperator sqlOperator, bool condition)
        {
            FieldName = fieldName;
            FieldValue = beginValue;
            EndValue = endValue;
            SqlOperator = sqlOperator;
            Condition = condition;
        }
        #endregion
    }
}
