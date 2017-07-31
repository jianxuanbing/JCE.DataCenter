using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Repositories.Impl
{
    /// <summary>
    /// 数据库视图项 仓储
    /// </summary>        
    public partial class DatabaseViewItemRepository:RepositoryBase<DatabaseViewItem,Guid>,IDatabaseViewItemRepository
    {
        /// <summary>
        /// 初始化一个<see cref="DatabaseViewItemRepository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DatabaseViewItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }    
}

    