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

        public CurrencyDataService(ICurrenciesParserRepository currenciesParserRepository, ICurrencyRepository currencyRepository, IMapper mapper)
        {
            _currenciesParserRepository = currenciesParserRepository;
            _mapper = mapper;
        }

        public IEnumerable<CurrencyDTO> GetData(string selector) =>
            _mapper.Map<List<CurrencyDTO>>(_currenciesParserRepository.GetCurrencies(selector, @"https://m.select.by/kurs"));
    }
}
