using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IBankService
    {
        List<BankDTO> GetData();
        void Add(BankDTO bank);
        void Update(BankDTO bank);
        void Delete(string id);
    }
}
