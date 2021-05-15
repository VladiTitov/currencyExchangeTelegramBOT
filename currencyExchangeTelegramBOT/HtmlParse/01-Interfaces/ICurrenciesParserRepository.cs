using System.Collections.Generic;
using DataAccess;

namespace HtmlParse
{
    public interface ICurrenciesParserRepository
    {
        IEnumerable<Currency> GetData(string selector, string url);
    }
}
