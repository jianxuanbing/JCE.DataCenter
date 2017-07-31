using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Repositories.Impl
{
    /// <summary>
    /// 数据库视图 仓储
    /// </summary>        
    public partial class DatabaseViewRepository:RepositoryBase<DatabaseView,Guid>,IDatabaseViewRepository
    {
        /// <summary>
        /// 初始化一个<see cref="DatabaseViewRepository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DatabaseViewRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }    
}

    