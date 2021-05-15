using System.Collections.Generic;
using DataAccess;

namespace HtmlParse
{
    public interface ICitiesParserRepository
    { 
        IEnumerable<City> GetData(string selector ,string url);
    }
}