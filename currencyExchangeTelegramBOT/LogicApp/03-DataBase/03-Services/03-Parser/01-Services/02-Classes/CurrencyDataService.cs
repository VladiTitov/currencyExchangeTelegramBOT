using System.Collections.Generic;
using AutoMapper;
using DataAccess.Repo;
using HtmlParse;

namespace BusinessLogic
{
    public class CurrencyDataService : ICurrencyWebDataService
    {
        private readonly ICurrenciesParserRepository _currenciesParserRepository;
        private readonly IMapper _mapper;

        public CurrencyDataService(ICurrenciesParserRepository currenciesParserRepository, IMapper mapper)
        {
            _currenciesParserRepository = currenciesParserRepository;
            _mapper = mapper;
        }

        public IEnumerable<CurrencyDTO> GetData(string selector, string url) =>
            _mapper.Map<List<CurrencyDTO>>(_currenciesParserRepository.GetCurrencies(selector, url));
    }
}
