using System.Collections.Generic;

namespace LogicApp
{
    public interface IBankService
    {
        List<BankDTO> GetData();
        void Add(BankDTO bank);
        void Update(BankDTO bank);
        void Delete(string id);
    }
}
