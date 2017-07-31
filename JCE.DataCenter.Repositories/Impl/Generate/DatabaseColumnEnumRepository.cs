using System;
using JCE.DataCenter.Domain.Model;
using JCE.DataCenter.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Uow;

namespace JCE.DataCenter.Repositories.Impl
{
    /// <summary>
    /// 数据库字段枚举 仓储
    /// </summary>        
    public partial class DatabaseColumnEnumRepository:RepositoryBase<DatabaseColumnEnum,Guid>,IDatabaseColumnEnumRepository
    {
        /// <summary>
        /// 初始化一个<see cref="DatabaseColumnEnumRepository"/>类型的实例
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DatabaseColumnEnumRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }    
}

    