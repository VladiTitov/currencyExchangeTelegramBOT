using System.Collections.Generic;
using DataAccess;

namespace HtmlParse
{
    public interface IMainDataParserRepository
    {
        IEnumerable<BaseEntityClass> GetData(string selector, string url);
    }
}
