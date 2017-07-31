using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Repositories.Impl
{
    /// <summary>
    /// 数据库库结构 仓储
    /// </summary>        
    public partial class DatabaseLibRepository:RepositoryBase<DatabaseLib,Guid>,IDatabaseLibRepository
    {
        /// <summary>
        /// 初始化一个<see cref="DatabaseLibRepository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DatabaseLibRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }    
}

    