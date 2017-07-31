using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Infrastructure.Domain.Repositories;

namespace JCE.DataCenter.Domain.Repositories
{
    /// <summary>
    /// 项目信息 仓储
    /// </summary>        
    public partial interface IProjectInfoRepository:IRepository<ProjectInfo,Guid>
    {
       
    }    
}

    