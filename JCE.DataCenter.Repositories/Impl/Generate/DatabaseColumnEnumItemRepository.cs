using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Repositories.Impl
{
    /// <summary>
    /// 数据库字段枚举项 仓储
    /// </summary>        
    public partial class DatabaseColumnEnumItemRepository:RepositoryBase<DatabaseColumnEnumItem,Guid>,IDatabaseColumnEnumItemRepository
    {
        /// <summary>
        /// 初始化一个<see cref="DatabaseColumnEnumItemRepository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DatabaseColumnEnumItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }    
}

    