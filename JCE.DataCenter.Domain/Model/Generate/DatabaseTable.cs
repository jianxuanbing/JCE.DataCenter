//----------DatabaseTable开始----------    
using System;
using JCE.DataCenter.Infrastructure.Domain.Entities;
using System.ComponentModel.DataAnnotations;
   
namespace JCE.DataCenter.Domain.Model
{
    /// <summary>
    /// 数据库表 
    /// </summary>        
    public partial class DatabaseTable:EntityBase<DatabaseTable,Guid>
    {            
        #region Property(属性)
        
        /// <summary>
        /// 数据表ID
        /// </summary>
        [Key]
        public Guid Id {get;set;}   
        
        /// <summary>
        /// 数据库ID
        /// </summary>
        
        public Guid DbId {get;set;}   
        
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
//----------DatabaseTable结束----------
    