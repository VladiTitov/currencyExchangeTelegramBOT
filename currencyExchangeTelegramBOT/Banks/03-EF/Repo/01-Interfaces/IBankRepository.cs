using System.Collections.Generic;
using System.Threading.Tasks;
using Banks;

namespace DataAccess.Repo
{
    interface IBankRepository
    {
        IEnumerable<Bank> GetId(string id);
        void Add(Bank bank);
        void Delete(string id);
        void Update(Bank bank);

    }
}
