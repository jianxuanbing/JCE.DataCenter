

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.EntityFramework.Uow;


namespace JCE.DataCenter.Repositories
{
    /// <summary>
    /// 数据中心 工作单元
    /// </summary>        
    public partial class DataCenterUnitOfWork:UnitOfWork,IDataCenterUnitOfWork
    {    
        #region 实体集合
        
        /// <summary>
        /// 数据库列集合
        /// </summary>
        public DbSet<DatabaseColumn> DatabaseColumnDs { get; set; }
        
        /// <summary>
        /// 数据库字段枚举集合
        /// </summary>
        public DbSet<DatabaseColumnEnum> DatabaseColumnEnumDs { get; set; }
        
        /// <summary>
        /// 数据库字段枚举项集合
        /// </summary>
        public DbSet<DatabaseColumnEnumItem> DatabaseColumnEnumItemDs { get; set; }
        
        /// <summary>
        /// 数据库连接集合
        /// </summary>
        public DbSet<DatabaseConnection> DatabaseConnectionDs { get; set; }
        
        /// <summary>
        /// 数据库库结构集合
        /// </summary>
        public DbSet<DatabaseLib> DatabaseLibDs { get; set; }
        
        /// <summary>
        /// 数据库表集合
        /// </summary>
        public DbSet<DatabaseTable> DatabaseTableDs { get; set; }
        
        /// <summary>
        /// 数据库表关系集合
        /// </summary>
        public DbSet<DatabaseTableRelation> DatabaseTableRelationDs { get; set; }
        
        /// <summary>
        /// 数据库视图集合
        /// </summary>
        public DbSet<DatabaseView> DatabaseViewDs { get; set; }
        
        /// <summary>
        /// 数据库视图项集合
        /// </summary>
        public DbSet<DatabaseViewItem> DatabaseViewItemDs { get; set; }
        
        /// <summary>
        /// 项目信息集合
        /// </summary>
        public DbSet<ProjectInfo> ProjectInfoDs { get; set; }
        
        /// <summary>
        /// 项目关联表集合
        /// </summary>
        public DbSet<ProjectRelateTable> ProjectRelateTableDs { get; set; }
        
        #endregion        
    }    
}
