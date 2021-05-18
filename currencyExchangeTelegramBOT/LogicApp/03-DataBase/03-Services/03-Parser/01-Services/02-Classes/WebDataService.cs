using System.Collections.Generic;
using AutoMapper;
using DataAccess;
using HtmlParse;

namespace BusinessLogic
{
    public class WebDataService : IWebDataService
    {
        private readonly IMainDataParserRepository _mainDataParserRepository;
        private readonly IMapper _mapper;

        public WebDataService(IMainDataParserRepository mainDataParserRepository, IMapper mapper)
        {
            _mainDataParserRepository = mainDataParserRepository;
            _mapper = mapper;
        }

        public IEnumerable<BaseEntityDTO> GetData(string selector, string url) =>
            _mapper.Map<List<BaseEntityDTO>>(_mainDataParserRepository.GetData(selector, url));
    }
}
