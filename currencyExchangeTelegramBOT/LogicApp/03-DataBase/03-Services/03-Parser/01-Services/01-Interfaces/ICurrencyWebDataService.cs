using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ICurrencyWebDataService
    {
        IEnumerable<CurrencyDTO> GetData(string selector, string url);
    }
}
