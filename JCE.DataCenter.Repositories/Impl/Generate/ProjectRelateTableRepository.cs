using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Repositories.Impl
{
    /// <summary>
    /// 项目关联表 仓储
    /// </summary>        
    public partial class ProjectRelateTableRepository:RepositoryBase<ProjectRelateTable,Guid>,IProjectRelateTableRepository
    {
        /// <summary>
        /// 初始化一个<see cref="ProjectRelateTableRepository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ProjectRelateTableRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }    
}

    