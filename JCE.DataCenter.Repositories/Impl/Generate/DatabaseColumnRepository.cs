using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Repositories.Impl
{
    /// <summary>
    /// 数据库列 仓储
    /// </summary>        
    public partial class DatabaseColumnRepository:RepositoryBase<DatabaseColumn,Guid>,IDatabaseColumnRepository
    {
        /// <summary>
        /// 初始化一个<see cref="DatabaseColumnRepository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DatabaseColumnRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }    
}

    