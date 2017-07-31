using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Infrastructure.Domain.Repositories;

namespace JCE.DataCenter.Domain.Repositories
{
    /// <summary>
    /// 数据库视图项 仓储
    /// </summary>        
    public partial interface IDatabaseViewItemRepository:IRepository<DatabaseViewItem,Guid>
    {
       
    }    
}

    