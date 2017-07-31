using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Repositories.Impl
{
    /// <summary>
    /// 项目信息 仓储
    /// </summary>        
    public partial class ProjectInfoRepository:RepositoryBase<ProjectInfo,Guid>,IProjectInfoRepository
    {
        /// <summary>
        /// 初始化一个<see cref="ProjectInfoRepository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ProjectInfoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }    
}

    