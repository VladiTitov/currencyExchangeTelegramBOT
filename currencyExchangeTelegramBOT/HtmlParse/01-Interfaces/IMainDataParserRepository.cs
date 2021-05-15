using System.Collections.Generic;

namespace HtmlParse
{
    public interface IMainDataParserRepository
    {
        IEnumerable<IEnumerable<string>> GetData(string selector, string url);
    }
}
