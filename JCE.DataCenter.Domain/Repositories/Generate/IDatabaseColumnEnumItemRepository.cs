using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Infrastructure.Domain.Repositories;

namespace JCE.DataCenter.Domain.Repositories
{
    /// <summary>
    /// 数据库字段枚举项 仓储
    /// </summary>        
    public partial interface IDatabaseColumnEnumItemRepository:IRepository<DatabaseColumnEnumItem,Guid>
    {
       
    }    
}

    