using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Repositories.Impl
{
    /// <summary>
    /// 数据库表关系 仓储
    /// </summary>        
    public partial class DatabaseTableRelationRepository:RepositoryBase<DatabaseTableRelation,Guid>,IDatabaseTableRelationRepository
    {
        /// <summary>
        /// 初始化一个<see cref="DatabaseTableRelationRepository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DatabaseTableRelationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }    
}

    