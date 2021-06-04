using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinessLogic
{
    public interface IBankService
    {
        List<BankDTO> GetData();
        void Add(BankDTO item);
        void Update(BankDTO item);
        void Delete(BankDTO item);
        IEnumerable<BankDTO> GetWithInclude(BankDTO item);
    }
}
