using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Repositories.Impl
{
    /// <summary>
    /// 数据库表 仓储
    /// </summary>        
    public partial class DatabaseTableRepository:RepositoryBase<DatabaseTable,Guid>,IDatabaseTableRepository
    {
        /// <summary>
        /// 初始化一个<see cref="DatabaseTableRepository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DatabaseTableRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }    
}

    