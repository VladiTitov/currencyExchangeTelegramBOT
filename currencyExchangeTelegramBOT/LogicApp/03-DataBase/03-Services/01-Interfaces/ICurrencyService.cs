using System.Collections.Generic;

namespace LogicApp
{
    public interface ICurrencyService
    {
        List<CurrencyDTO> GetData();
        void Add(CurrencyDTO currency);
        void Update(CurrencyDTO currency);
        void Delete(string id);
    }
}
