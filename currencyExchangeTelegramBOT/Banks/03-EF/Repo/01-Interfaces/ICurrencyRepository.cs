using System.Collections.Generic;
using Banks;

namespace DataAccess.Repo
{
    interface ICurrencyRepository
    {
        IEnumerable<Currency> GetId(string id);
        void Add(Currency currency);
        void Delete(string id);
        void Update(Currency currency);
    }
}
