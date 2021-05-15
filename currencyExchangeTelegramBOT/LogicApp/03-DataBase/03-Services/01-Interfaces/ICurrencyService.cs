using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ICurrencyService
    {
        List<CurrencyDTO> GetData();
        void Add(CurrencyDTO currency);
        void Update(CurrencyDTO currency);
        void Delete(CurrencyDTO item);
    }
}
