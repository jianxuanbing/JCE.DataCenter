using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Infrastructure.Domain.Repositories;

namespace JCE.DataCenter.Domain.Repositories
{
    /// <summary>
    /// 数据库连接 仓储
    /// </summary>        
    public partial interface IDatabaseConnectionRepository:IRepository<DatabaseConnection,Guid>
    {
       
    }    
}

    