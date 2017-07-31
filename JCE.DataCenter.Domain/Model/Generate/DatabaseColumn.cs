//----------DatabaseColumn开始----------    
using System;
using JCE.DataCenter.Infrastructure.Domain.Entities;
using System.ComponentModel.DataAnnotations;
   
namespace JCE.DataCenter.Domain.Model
{
    /// <summary>
    /// 数据库列 
    /// </summary>        
    public partial class DatabaseColumn:EntityBase<DatabaseColumn,Guid>
    {            
        #region Property(属性)
        
        /// <summary>
        /// 数据列ID
        /// </summary>
        [Key]
        public Guid Id {get;set;}   
        
        /// <summary>
        /// 数据表ID
        /// </summary>
        
        public Guid DbTableId {get;set;}   
        
        /// <summary>
        /// 名称
        /// </summary>
        
        public string Name {get;set;}   
        
        /// <summary>
        /// 说明
        /// </summary>
        
        public string Desc {get;set;}   
        
        /// <summary>
        /// 备注
        /// </summary>
        
        public string Note {get;set;}   
        
        /// <summary>
        /// 是否主键,1:是,0:否
        /// </summary>
        
        public int IsPk {get;set;}   
        
        /// <summary>
        /// 是否标识列,1:是,0:否
        /// </summary>
        
        public int IsIdentity {get;set;}   
        
        /// <summary>
        /// 是否可空,1:是,0:否
        /// </summary>
        
        public int IsNull {get;set;}   
        
        /// <summary>
        /// 字段默认值
        /// </summary>
        
        public string DefaultValue {get;set;}   
        
        /// <summary>
        /// 排序
        /// </summary>
        
        public int? OrderNo {get;set;}   
        
        /// <summary>
        /// 状态,0:停用,1:启用
        /// </summary>
        
        public int Status {get;set;}   
        
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
        
        #endregion
    }    
}
//----------DatabaseColumn结束----------
    