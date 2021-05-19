using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetData();
        void Add(TEntity bank);
        void Update(TEntity bank);
        void Delete(TEntity item);
    }
}
