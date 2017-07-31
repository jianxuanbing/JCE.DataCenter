using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Infrastructure.Domain.Repositories;

namespace JCE.DataCenter.Domain.Repositories
{
    /// <summary>
    /// 项目关联表 仓储
    /// </summary>        
    public partial interface IProjectRelateTableRepository:IRepository<ProjectRelateTable,Guid>
    {
       
    }    
}

    