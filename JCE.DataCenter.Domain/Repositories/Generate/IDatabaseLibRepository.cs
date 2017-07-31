using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Infrastructure.Domain.Repositories;

namespace JCE.DataCenter.Domain.Repositories
{
    /// <summary>
    /// 数据库库结构 仓储
    /// </summary>        
    public partial interface IDatabaseLibRepository:IRepository<DatabaseLib,Guid>
    {
       
    }    
}

    