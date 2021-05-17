using System;
using System.Collections.Generic;

namespace DataAccess.Repo
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity bank);
        void Delete(TEntity item);
        void Update(TEntity bank);
        void Dispose();
    }
}
