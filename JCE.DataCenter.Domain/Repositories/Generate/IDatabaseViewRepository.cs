using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Infrastructure.Domain.Repositories;

namespace JCE.DataCenter.Domain.Repositories
{
    /// <summary>
    /// 数据库视图 仓储
    /// </summary>        
    public partial interface IDatabaseViewRepository:IRepository<DatabaseView,Guid>
    {
       
    }    
}

    