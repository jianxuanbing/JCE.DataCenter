//----------DatabaseTableRelation开始----------    
using System;
using JCE.DataCenter.Infrastructure.Domain.Entities;
using System.ComponentModel.DataAnnotations;
   
namespace JCE.DataCenter.Domain.Model
{
    /// <summary>
    /// 数据库表关系 
    /// </summary>        
    public partial class DatabaseTableRelation:EntityBase<DatabaseTableRelation,Guid>
    {            
        #region Property(属性)
        
        /// <summary>
        /// 数据表关系Id
        /// </summary>
        [Key]
        public Guid Id {get;set;}   
        
        /// <summary>
        /// 源数据表Id
        /// </summary>
        
        public Guid DbTableId {get;set;}   
        
        /// <summary>
        /// 源数据列Id
        /// </summary>
        
        public Guid DbColumnId {get;set;}   
        
        /// <summary>
        /// 目标数据表Id
        /// </summary>
        
        public Guid TargetDbTableId {get;set;}   
        
        /// <summary>
        /// 目标数据列Id
        /// </summary>
        
        public Guid TargetDbColumnId {get;set;}   
        
        /// <summary>
        /// 关系类型,0:外键
        /// </summary>
        
        public int Type {get;set;}   
        
        /// <summary>
        /// 创建时间
        /// </summary>
        
        public DateTime CreateTime {get;set;}   
        
        /// <summary>
        /// 创建人
        /// </summary>
        
        public string Creater {get;set;}   
        
        /// <summary>
        /// 编辑时间
        /// </summary>
        
        public DateTime EditTime {get;set;}   
        
        /// <summary>
        /// 编辑人
        /// </summary>
        
        public string Editor {get;set;}   
        
        /// <summary>
        /// 备注
        /// </summary>
        
        public string Note {get;set;}   
        
        #endregion
    }    
}
//----------DatabaseTableRelation结束----------
    