using System.Collections.Generic;
using DataAccess;

namespace HtmlParse
{
    public interface ICitiesParserRepository
    { 
        IEnumerable<City> GetData(string key, string url);
    }
}