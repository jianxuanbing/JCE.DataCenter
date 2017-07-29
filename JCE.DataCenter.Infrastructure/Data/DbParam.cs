/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.Data
 * 文件名：DbParam
 * 版本号：v1.0.0.0
 * 唯一标识：42746708-60e2-47f0-8763-cb094b2ecb83
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 9:42:16
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 9:42:16
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.Data
{
    /// <summary>
    /// 数据库参数
    /// </summary>
    public class DbParam
    {
        object _value;

        /// <summary>
        /// 参数名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        public object Value
        {
            get { return this._value; }
            set
            {
                this._value = value;
                if (value != null)
                {
                    this.Type = value.GetType();
                }
            }
        }



        /// <summary>
        /// 数据库数据类型
        /// </summary>
        public DbType? DbType { get; set; }

        /// <summary>
        /// 精度
        /// </summary>
        public byte? Precision { get; set; }

        /// <summary>
        /// 比例
        /// </summary>
        public byte? Scale { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// 参数输入类型
        /// </summary>
        public ParameterDirection Direction { get; set; }

        /// <summary>
        /// 显示参数，如果设置了该自定义参数，框架内部就会忽略 DbParam 类的其他属性，使用该属性
        /// </summary>
        public IDbDataParameter ExplicitParameter { get; set; }

        /// <summary>
        /// 初始化一个<see cref="DbParam"/>类型的实例
        /// </summary>
        public DbParam()
        {            
            this.Direction=ParameterDirection.Input;
        }

        /// <summary>
        /// 初始化一个<see cref="DbParam"/>类型的实例
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        public DbParam(string name,object value):this()
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// 初始化一个<see cref="DbParam"/>类型的实例
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="type">数据类型</param>
        public DbParam(string name, object value, Type type):this(name,value)
        {
            this.Type = type;
        }

        /// <summary>
        /// 创建一个数据库参数
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public static DbParam Create<T>(string name, T value)
        {
            var param=new DbParam(name,value);
            if (value == null)
            {
                param.Type = typeof(T);
            }
            return param;
        }

        /// <summary>
        /// 创建一个数据库参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public static DbParam Create(string name, object value)
        {
            return new DbParam(name,value);
        }

        /// <summary>
        /// 创建一个数据库参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="type">数据类型</param>
        /// <returns></returns>
        public static DbParam Create(string name, object value, Type type)
        {
            return new DbParam(name,value,type);
        }
    }
}
