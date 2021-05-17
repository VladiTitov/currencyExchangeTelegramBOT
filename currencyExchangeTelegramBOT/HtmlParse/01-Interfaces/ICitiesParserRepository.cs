using System.Collections.Generic;
using DataAccess;

namespace HtmlParse
{
    public interface ICitiesParserRepository
    {
        IEnumerable<City> GetCities(string selector, string url);
    }
}