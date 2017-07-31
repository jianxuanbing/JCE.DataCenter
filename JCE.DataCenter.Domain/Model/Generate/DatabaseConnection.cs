//----------DatabaseConnection开始----------    
using System;
using JCE.DataCenter.Infrastructure.Domain.Entities;
using System.ComponentModel.DataAnnotations;
   
namespace JCE.DataCenter.Domain.Model
{
    /// <summary>
    /// 数据库连接 
    /// </summary>        
    public partial class DatabaseConnection:EntityBase<DatabaseConnection,Guid>
    {            
        #region Property(属性)
        
        /// <summary>
        /// 数据库连接ID
        /// </summary>
        [Key]
        public Guid Id {get;set;}   
        
        /// <summary>
        /// 服务器名称
        /// </summary>
        
        public string ServiceName {get;set;}   
        
        /// <summary>
        /// 登录名
        /// </summary>
        
        public string UserName {get;set;}   
        
        /// <summary>
        /// 密码
        /// </summary>
        
        public string Password {get;set;}   
        
        /// <summary>
        /// 数据库类型,0:SqlServer,1:MySql
        /// </summary>
        
        public int DataType {get;set;}   
        
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
//----------DatabaseConnection结束----------
    