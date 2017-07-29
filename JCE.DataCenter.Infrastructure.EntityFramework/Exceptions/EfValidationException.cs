/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Exceptions
 * 文件名：EfValidationException
 * 版本号：v1.0.0.0
 * 唯一标识：5c7478ac-eb33-41c5-a8de-76c0f4b74e69
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 14:17:18
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 14:17:18
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Exceptions
{
    /// <summary>
    /// Entity Framework实体验证异常
    /// </summary>
    public class EfValidationException : DbEntityValidationException
    {

        /// <summary>
        /// 初始化一个<see cref="EfValidationException"/>类型的实例
        /// </summary>
        /// <param name="exception">异常</param>
        public EfValidationException(DbEntityValidationException exception) : base("验证失败:", exception)
        {
            SetExceptionDatas(exception);
        }

        /// <summary>
        /// 设置异常数据
        /// </summary>
        /// <param name="exception">异常</param>
        private void SetExceptionDatas(DbEntityValidationException exception)
        {
            foreach (DbEntityValidationResult errors in exception.EntityValidationErrors)
            {
                foreach (DbValidationError error in errors.ValidationErrors)
                {
                    Data.Add(string.Format("{0}属性验证失败", error.PropertyName), error.ErrorMessage);
                }
            }
        }
    }
}
