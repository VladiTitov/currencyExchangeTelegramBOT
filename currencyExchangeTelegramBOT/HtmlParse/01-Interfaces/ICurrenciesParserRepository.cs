using System.Collections.Generic;
using DataAccess;

namespace HtmlParse
{
    public interface ICurrenciesParserRepository
    {
        IEnumerable<Currency> GetCurrencies(string selector, string url);
    }
}
