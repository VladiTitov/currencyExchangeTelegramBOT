using System.Collections.Generic;
using AutoMapper;
using HtmlParse;

namespace BusinessLogic
{
    public class WebDataService : IWebDataService
    {
        private readonly IMainDataParserRepository _mainDataParserRepository;

        public WebDataService(IMainDataParserRepository mainDataParserRepository) =>
            _mainDataParserRepository = mainDataParserRepository;

        public IEnumerable<IEnumerable<string>> GetData(string selector, string url) =>
            _mainDataParserRepository.GetData(selector, url);
    }
}
