/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.SqlBuilder.Where
 * 文件名：WhereCondition
 * 版本号：v1.0.0.0
 * 唯一标识：6341840f-7d89-46ad-a512-2e2672bd5c96
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 9:28:46
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 9:28:46
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JCE.Utils.Extensions;
using JCE.Utils.Modes;

namespace JCE.DataCenter.Infrastructure.SqlBuilder.Where
{
    /// <summary>
    /// Where条件
    /// </summary>
    public class WhereCondition
    {
        /// <summary>
        /// Where列表
        /// </summary>
        private IList<WhereInfo> WhereList=new List<WhereInfo>();

        /// <summary>
        /// 条件字典
        /// </summary>
        private Dictionary<string,WhereInfo> ConditionDic=new Dictionary<string, WhereInfo>();

        /// <summary>
        /// 参数值，记录参数（名-值）
        /// </summary>
        protected Dictionary<string,object> ParamValues=new Dictionary<string, object>();

        /// <summary>
        /// 动态参数类
        /// </summary>
        protected IList<DynamicPropertyModel> DynamicParam;

        /// <summary>
        /// 添加条件
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="sqlOperator">操作符</param>
        /// <param name="condition">拼接条件</param>
        /// <returns></returns>
        public WhereCondition AddCondition(string field, object value, SqlOperator sqlOperator,bool condition=true)
        {
            this.ConditionDic.Add(field,new WhereInfo(field, value, sqlOperator,true));
            return this;
        }

        /// <summary>
        /// 添加Sql
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="condition">拼接条件</param>
        /// <returns></returns>
        public WhereCondition AddSqlCondition(string sql, bool condition=true)
        {
            this.ConditionDic.Add(sql,new WhereInfo(sql,condition));
            return this;
        }

        /// <summary>
        /// 添加Between条件
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="beginValue">开始值</param>
        /// <param name="endValue">结束值</param>
        /// <param name="condition">拼接条件</param>
        /// <returns></returns>
        public WhereCondition AddBetweenCondition(string fieldName, object beginValue, object endValue, bool condition=true)
        {
            if (beginValue.GetType() != endValue.GetType())
            {
                throw new Exception("Between 参数类型不一致!");
            }
            this.ConditionDic.Add(fieldName,new WhereInfo(fieldName,beginValue,endValue,SqlOperator.Between,condition));
            return this;
        }

        /// <summary>
        /// 构建Sql
        /// </summary>
        /// <returns></returns>
        public string BuildSql()
        {
            string sql = " (1=1) ";
            StringBuilder sb=new StringBuilder();
            WhereInfo whereInfo = null;
            foreach (var item in ConditionDic)
            {
                whereInfo = item.Value;
                // 如果不满足条件，则跳过
                if (!whereInfo.Condition)
                {
                    continue;
                }
                // 如果转换为字符串为空，则跳过
                if (whereInfo.FieldValue.ToString().IsNullOrEmpty())
                {
                    continue;
                }
                // 如果Guid为空，则跳过
                if (whereInfo.Type == typeof(Guid) && ((Guid) whereInfo.FieldValue).IsEmpty())
                {
                    continue;
                }
                // 如果Sql条件不为空，则拼接后，忽略后续操作            
                if (!whereInfo.SqlWhere.IsNullOrEmpty())
                {
                    sb.AppendFormat(" AND {0}", whereInfo.SqlWhere);
                    continue;
                }

                if (whereInfo.SqlOperator == SqlOperator.Like)
                {
                    whereInfo.FieldValue = whereInfo.FieldValue.ToString().Replace("'", "''");
                    sb.AppendFormat(" AND {0} {1} '{2}'", whereInfo.FieldName,
                        this.ConvertSqlOperator(whereInfo.SqlOperator), string.Format("%{0}%", whereInfo.FieldValue));
                }
                else if (whereInfo.SqlOperator == SqlOperator.In)
                {
                    var list = (IList) whereInfo.FieldValue;
                    StringBuilder sbIn = new StringBuilder();
                    foreach (var obj in list)
                    {
                        sbIn.AppendFormat("'{0}',", obj.ToString());
                    }
                    string inSql = sbIn.ToString().TrimEnd(',');
                    sb.AppendFormat(" AND {0} {1} ({2})", whereInfo.FieldName,
                        this.ConvertSqlOperator(whereInfo.SqlOperator), inSql);
                }
                else if (whereInfo.SqlOperator == SqlOperator.Between)
                {
                    if (whereInfo.FieldValue != null && whereInfo.EndValue != null)
                    {
                        sb.AppendFormat(" AND {0} {1} {2} AND {3}", whereInfo.FieldName,
                            this.ConvertSqlOperator(whereInfo.SqlOperator),
                            this.ConvertParamValue(whereInfo.Type, whereInfo.FieldValue),
                            this.ConvertParamValue(whereInfo.Type, whereInfo.EndValue));
                    }
                    else
                    {
                        if (whereInfo.FieldValue != null && whereInfo.EndValue == null)
                        {
                            sb.AppendFormat(" And {0} {1} {2}", whereInfo.FieldName,
                                this.ConvertSqlOperator(SqlOperator.GreaterThanEqual),
                                this.ConvertParamValue(whereInfo.Type, whereInfo.FieldValue));
                        }
                        else if(whereInfo.FieldValue==null&&whereInfo.EndValue!=null)
                        {
                            sb.AppendFormat(" And {0} {1} {2}", whereInfo.FieldName,
                                this.ConvertSqlOperator(SqlOperator.LessThanEqual),
                                this.ConvertParamValue(whereInfo.Type, whereInfo.EndValue));
                        }
                    }
                }                
                else
                {
                    sb.AppendFormat(" AND {0} {1} {2}", whereInfo.FieldName,
                        this.ConvertSqlOperator(whereInfo.SqlOperator),
                        this.ConvertParamValue(whereInfo.Type, whereInfo.FieldValue));
                }
            }

            sql += sb.ToString();
            return sql;

        }


        /// <summary>
        /// 辅助枚举类型为对应的Sql语句操作符号
        /// </summary>
        /// <param name="sqlOperator">操作符</param>
        /// <returns></returns>
        private string ConvertSqlOperator(SqlOperator sqlOperator)
        {
            switch (sqlOperator)
            {
                case SqlOperator.Like:
                case SqlOperator.LikeLeft:
                case SqlOperator.LikeRight:
                    return "like";
                case SqlOperator.Equal:
                    return "=";
                case SqlOperator.NotEqual:
                    return "<>";
                case SqlOperator.GreaterThan:
                    return ">";
                case SqlOperator.GreaterThanEqual:
                    return ">=";
                case SqlOperator.LessThan:
                    return "<";
                case SqlOperator.LessThanEqual:
                    return "<=";
                case SqlOperator.In:
                    return "in";
                case SqlOperator.Between:
                    return "between";
                default:
                    return "=";
            }
        }

        /// <summary>
        /// 转换参数值
        /// </summary>
        /// <param name="type">参数类型</param>
        /// <param name="fieldValue">参数值</param>
        /// <returns></returns>
        private string ConvertParamValue(Type type,object fieldValue)
        {
            if (type == typeof(int) || type == typeof(long))
            {
                return fieldValue.ToString();
            }
            else
            {
                return string.Format("'{0}'", fieldValue);
            }
        }

        /// <summary>
        /// 动态添加参数对象，根据方法与值
        /// </summary>
        /// <param name="sqlOperator">操作符</param>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns>动态属性对象</returns>
        private DynamicPropertyModel AddParam(SqlOperator sqlOperator, string field, object value)
        {
            if (DynamicParam == null)
            {
                DynamicParam=new List<DynamicPropertyModel>();
            }
            var model = new DynamicPropertyModel() {Name = field + GetParamIndex(field), PropertyType = value.GetType()};
            DynamicParam.Add(model);
            switch (sqlOperator)
            {
                case SqlOperator.Like:
                    ParamValues.Add(model.Name,string.Format("%{0}%",value));
                    break;
                case SqlOperator.LikeLeft:
                    ParamValues.Add(model.Name,string.Format("%{0}",value));
                    break;
                case SqlOperator.LikeRight:
                    ParamValues.Add(model.Name,string.Format("{0}%",value));
                    break;
                case SqlOperator.NotEqual:                
                case SqlOperator.Equal:
                case SqlOperator.GreaterThan:
                case SqlOperator.GreaterThanEqual:
                case SqlOperator.LessThan:
                case SqlOperator.LessThanEqual:
                case SqlOperator.In:
                    ParamValues.Add(model.Name,value);
                    break;
            }
            return model;
        }

        /// <summary>
        /// 获取参数索引
        /// </summary>
        /// <param name="field">字段名</param>
        /// <returns>参数索引</returns>
        private string GetParamIndex(string field)
        {
            var key = ParamValues.Keys.FirstOrDefault(m => m.StartsWith(field));
            if (key == null)
            {
                return "1";
            }
            return (int.Parse(key.Remove(0, field.Length)) + 1).ToString();
        }
    }
}
