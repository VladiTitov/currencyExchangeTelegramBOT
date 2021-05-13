using System.Collections.Generic;

namespace DataAccess.Repo
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> Get(string id);
        IEnumerable<Currency> GetAll();
        void Add(Currency currency);
        void Delete(string id);
        void Update(Currency currency);
    }
}
