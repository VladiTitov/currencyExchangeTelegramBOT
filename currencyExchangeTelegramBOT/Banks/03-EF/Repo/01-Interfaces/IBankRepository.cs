using System.Collections.Generic;
using System.Threading.Tasks;
using Banks;

namespace DataAccess.Repo
{
    interface IBankRepository
    {
        IEnumerable<Bank> GetByBankId(string bankId);
        string Create(Bank bank);
        void DeleteBank(string id);
        void UpdateBank(Bank bank);

    }
}
