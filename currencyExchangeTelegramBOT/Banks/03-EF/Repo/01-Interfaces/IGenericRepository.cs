using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Repo
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity bank);
        void Delete(TEntity item);
        void Update(TEntity bank);

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);

        void Dispose();
    }
}
