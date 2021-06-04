using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public interface IBankService
    {
        List<BankDTO> GetData();
        void Add(BankDTO bank);
        void Update(BankDTO bank);
        void Delete(BankDTO item);
    }
}
