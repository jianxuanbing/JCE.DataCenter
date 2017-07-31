using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Repositories.Impl
{
    /// <summary>
    /// 数据库连接 仓储
    /// </summary>        
    public partial class DatabaseConnectionRepository:RepositoryBase<DatabaseConnection,Guid>,IDatabaseConnectionRepository
    {
        /// <summary>
        /// 初始化一个<see cref="DatabaseConnectionRepository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DatabaseConnectionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }    
}

    