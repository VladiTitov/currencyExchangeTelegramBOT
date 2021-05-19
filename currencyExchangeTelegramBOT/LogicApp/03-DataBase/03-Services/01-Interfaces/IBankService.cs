using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IBankService
    {
        List<BankDTO> GetData();
        void Add(BaseEntityDTO bank);
        void Update(BaseEntityDTO bank);
        void Delete(BaseEntityDTO item);
    }
}
