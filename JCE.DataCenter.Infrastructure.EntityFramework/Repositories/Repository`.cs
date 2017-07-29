/************************************************************************************
 * Copyright (c) 2017 All Rights Reserved. 
 * CLR版本：4.0.30319.42000
 * 机器名称：JIAN
 * 命名空间：JCE.DataCenter.Infrastructure.EntityFramework.Repositories
 * 文件名：Repository_
 * 版本号：v1.0.0.0
 * 唯一标识：1708423b-1e7b-4c62-84a9-6f6fc7c03e69
 * 当前的用户域：JIAN
 * 创建人：简玄冰
 * 电子邮箱：jianxuanhuo1@126.com
 * 创建时间：2017/7/12 17:01:34
 * 描述：
 *
 * =====================================================================
 * 修改标记：
 * 修改时间：2017/7/12 17:01:34
 * 修改人：简玄冰
 * 版本号：v1.0.0.0
 * 描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JCE.Utils.Extensions;
using EntityFramework.Extensions;
using JCE.DataCenter.Infrastructure.CommonModel;
using JCE.DataCenter.Infrastructure.Domain.Entities;
using JCE.DataCenter.Infrastructure.Domain.Repositories;
using JCE.DataCenter.Infrastructure.Domain.Repositories.Pager;
using JCE.DataCenter.Infrastructure.Domain.Uow;
using JCE.DataCenter.Infrastructure.EntityFramework.DBContext;
using JCE.DataCenter.Infrastructure.EntityFramework.Extensions;

namespace JCE.DataCenter.Infrastructure.EntityFramework.Repositories
{
    /// <summary>
    /// 仓储基类，定义仓储模型中的数据操作标准
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract partial class Repository<TEntity, TKey> : Repository, IRepository<TEntity, TKey> where TEntity : class, IEntity<TEntity, TKey>
    {
        private readonly DbSet<TEntity> _dbSet;

        private DbSet<TEntity> Set
        {
            get { return this._dbSet; }
        }

        public IQueryable<TEntity> Entities
        {
            get { return _dbSet.AsNoTracking(); }
        }

        public IQueryable<TEntity> TrackEntities
        {
            get { return _dbSet; }
        }

        protected Repository(DbContextFactory factory) : base(factory)
        {
        }

        protected Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbSet = UnitOfWork.Set<TEntity>();
        }

        #region Insert(增)
        public void Insert(TEntity entity)
        {
            Set.Add(entity);
            UnitOfWork.CommitByStart();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return;
            }
            Set.AddRange(entities);
            UnitOfWork.CommitByStart();
        }
        #endregion

        #region Delete(删)
        public void Delete(TEntity entity)
        {
            Remove(entity);
            UnitOfWork.CommitByStart();
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="entity">实体</param>
        private void Remove(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }
            Attach(entity);
            Set.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Set.Where(predicate);
            Delete(entities);
        }

        public void BatchDelete(Expression<Func<TEntity, bool>> predicate)
        {
            Set.Where(predicate).Delete();
            UnitOfWork.CommitByStart();
        }

        public void Delete(object id)
        {
            var entity = FindById(id);
            if (entity == null)
            {
                return;
            }
            Delete(entity);
        }

        //public void Delete(IEnumerable<TKey> ids)
        //{
        //    if (ids == null)
        //    {
        //        return;
        //    }
        //    Delete(FindByIds(ids.ToList()));
        //}

        public void Delete(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return;
            }
            var list = entities.ToList();
            if (!list.Any())
            {
                return;
            }
            foreach (var entity in list)
            {
                Remove(entity);
            }
            UnitOfWork.CommitByStart();
        }
        #endregion

        #region Update(改)
        public void Update(TEntity entity)
        {
            Attach(entity);
            UnitOfWork.Entry(entity).State = EntityState.Modified;
            UnitOfWork.CommitByStart();
        }

        public void Update(TEntity newEntity, TEntity oldEntity)
        {
            UnitOfWork.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            UnitOfWork.CommitByStart();
        }

        public void Update(TEntity entity, List<string> properties, bool isProUpdate = true)
        {
            if (entity == null)
            {
                throw new Exception("实体不能为空!");
            }
            if (isProUpdate)
            {
                UpdateProperty(entity, properties);
            }
            else
            {
                List<string> list = new List<string>();
                foreach (PropertyInfo property in entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (property.GetValue(entity) != null)
                    {
                        list.Add(property.Name);
                    }
                }
                if (properties.Count > 0)
                {
                    list.RemoveAll(properties.Contains);
                }
                UpdateProperty(entity, list);
            }
        }

        public void UpdateProperty(TEntity entity, List<string> properties)
        {

            if (properties.Any() == false)
            {
                throw new Exception("需要修改的属性至少要有一个!");
            }
            //将entity追加到EF容器                
            DbEntityEntry entry = UnitOfWork.Entry(entity);
            entry.State = EntityState.Unchanged;
            foreach (var item in properties)
            {
                entry.Property(item).IsModified = true;
            }
            //关闭EF对实体的合法性验证参数
            UnitOfWork.Configuration.ValidateOnSaveEnabled = false;
            UnitOfWork.CommitByStart();
        }

        public void Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            Set.Where(predicate).Update(updateExpression);
            UnitOfWork.CommitByStart();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public void Update(TEntity entity, Expression<Func<TEntity, bool>> predicate, params string[] modifiedProNames)
        {
            List<TEntity> listModifing = Set.Where(predicate).ToList();
            Type type = typeof(TEntity);
            List<PropertyInfo> propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            Dictionary<string, PropertyInfo> dicPros = new Dictionary<string, PropertyInfo>();
            propertyInfos.ForEach(x =>
            {
                if (modifiedProNames.Contains(x.Name))
                {
                    dicPros.Add(x.Name, x);
                }
            });
            if (dicPros.Count < 0)
            {
                throw new Exception("指定修改的字段名称有误或为空!");
            }
            foreach (var item in dicPros)
            {
                PropertyInfo proInfo = item.Value;
                //取出要修改的值
                object newValue = proInfo.GetValue(entity, null);
                //批量设置要修改对象的属性
                foreach (var model in listModifing)
                {
                    //为要修改的对象的要修改的属性设置新的值
                    proInfo.SetValue(model, newValue, null);
                }
            }
        }
        #endregion

        #region Select(查)
        public TEntity FindById(object id)
        {
            return SlaveDb.Set<TEntity>().Find(id);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return SlaveDb.Set<TEntity>().FirstOrDefault();
            }
            return SlaveDb.Set<TEntity>().FirstOrDefault(predicate);
        }

        public List<TEntity> FindAll(string order = null)
        {
            return order == null ? SlaveDb.Set<TEntity>().ToList() : SlaveDb.Set<TEntity>().OrderBy(order).ToList();
        }

        public List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, string order = null)
        {
            var query = SlaveDb.Set<TEntity>().Where(predicate);
            return order == null ? query.ToList() : query.OrderBy(order).ToList();
        }

        //public List<TEntity> FindByIds(IEnumerable<TKey> ids)
        //{
        //    if (ids == null)
        //    {
        //        return null;
        //    }
        //    return SlaveDb.Set<TEntity>().Where(x => ids.Contains(x.Id)).ToList();
        //}

        public IQueryable<TEntity> FindAsNoTraking(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? SlaveDb.Set<TEntity>().AsNoTracking()
                : SlaveDb.Set<TEntity>().AsNoTracking().Where(predicate);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate == null
                ? SlaveDb.Set<TEntity>()
                : SlaveDb.Set<TEntity>().Where(predicate);
        }

        public TEntity this[TKey id]
        {
            get { return FindById(id); }
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return SlaveDb.Set<TEntity>().Any(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = SlaveDb.Set<TEntity>().AsNoTracking();
            return predicate == null
                ? query.Count()
                : query.Count(predicate);
        }

        public List<TEntity> Page(int page, int pageSize, out int total, Expression<Func<TEntity, TKey>> orderBy, Expression<Func<TEntity, bool>> predicate = null, bool desc = true)
        {
            IQueryable<TEntity> query = desc
                ? SlaveDb.Set<TEntity>().OrderByDescending(orderBy)
                : SlaveDb.Set<TEntity>().OrderBy(orderBy);
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            total = query.Count();
            return query.PageBy((page - 1) * pageSize, pageSize).ToList();
        }

        public List<TEntity> Page(int page, int pageSize, out int total, string order, Expression<Func<TEntity, bool>> predicate = null)
        {
            // 分页 一定注意： Skip 之前一定要 OrderBy
            IQueryable<TEntity> query = SlaveDb.Set<TEntity>().OrderBy(order);
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            total = query.Count();
            return query.PageBy((page - 1) * pageSize, pageSize).ToList();
        }

        public PagedResult<TResult> Page<TResult>(IQueryable<dynamic> query, int page, int pageSize, Func<dynamic, TResult> selector) where TResult : class, new()
        {
            int count = query.Count();
            IPager pager=new Pager(page,pageSize,count);
            PagedResult<TResult> result=new PagedResult<TResult>();
            result.Page = pager.Page;
            result.PageSize = pager.PageSize;
            result.TotalCount = pager.TotalCount;
            var temp = query.PageBy(pager).Select(selector).ToList();
            result.Data.AddRange(temp);
            return result;
        }       

        public List<TDto> Select<TDto>(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Other(其他)
        public void Save()
        {
            UnitOfWork.Commit();
        }

        public void Clear()
        {
            foreach (var entity in Set)
            {
                Set.Remove(entity);
            }
            UnitOfWork.CommitByStart();
        }

        public void ClearCache()
        {
            UnitOfWork.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Detached);
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return UnitOfWork;
        }

        public List<TEntity> SqlQuery(string sql, params object[] parms)
        {
            return SqlQuery<TEntity>(sql, parms);
        }
        #endregion

        #region 辅助方法
        /// <summary>
        /// 附加实体
        /// </summary>
        /// <param name="entity">实体</param>
        private void Attach(TEntity entity)
        {
            if (Set.Local.Contains(entity))
            {
                return;
            }
            Set.Attach(entity);
        }
        #endregion


    }
}
