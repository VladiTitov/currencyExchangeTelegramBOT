using System.Collections.Generic;
using Banks;

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
