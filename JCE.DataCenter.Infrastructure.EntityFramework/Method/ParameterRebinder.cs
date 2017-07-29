/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Method
 * 文件名：ParameterRebinder
 * 版本号：v1.0.0.0
 * 唯一标识：b997b06f-bf2e-4523-81b1-2e54d49d07e9
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/17 11:56:06
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/17 11:56:06
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Method
{
    /// <summary>
    /// 参数重绑器
    /// </summary>
    public class ParameterRebinder : ExpressionVisitor
    {
        /// <summary>
        /// 参数表达式映射字典
        /// </summary>
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        /// <summary>
        /// 初始化一个<see cref="ParameterRebinder"/>类型的实例
        /// </summary>
        /// <param name="map"></param>
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// 替换参数
        /// </summary>
        /// <param name="map">参数表达式映射字典</param>
        /// <param name="exp">表达式</param>
        /// <returns></returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map,
            Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        /// <summary>
        /// 组装表达式
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="first">表达式1</param>
        /// <param name="second">表达式2</param>
        /// <param name="merge">迁移合并函数</param>
        /// <returns></returns>
        public static Expression<T> Compose<T>(Expression<T> first, Expression<T> second,
            Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            // 构建参数映射
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            // 替换参数
            var secondBody = ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression
            // 组装表达式
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// 重写参数表达式，实现缓存
        /// </summary>
        /// <param name="node">参数表达式</param>
        /// <returns></returns>
        protected override Expression VisitParameter(ParameterExpression node)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(node, out replacement))
            {
                node = replacement;
            }
            return base.VisitParameter(node);
        }
    }
}
