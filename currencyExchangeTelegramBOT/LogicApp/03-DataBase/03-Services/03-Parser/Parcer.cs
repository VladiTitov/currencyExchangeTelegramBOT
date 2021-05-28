﻿using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using HtmlParse;

namespace BusinessLogic
{
    public class Parser
    {
        private readonly ICityService _cityService;
        private readonly ICityWebDataService _cityWebDataService;

        private readonly ICurrencyService _currencyService;
        private readonly ICurrencyWebDataService _currencyWebDataService;

        private readonly IWebDataService _webDataService;
        private readonly IMainDataParserRepository _dataParserRepository;

        private readonly IBranchService _branchService;
        private readonly IBankService _bankService;
        private readonly IQuotationService _quotationService;


        public Parser(ICityService cityService, ICityWebDataService cityWebDataService,
            ICurrencyService currencyService, ICurrencyWebDataService currencyWebDataService,
            IWebDataService webDataService, IMainDataParserRepository dataParserRepository,
            IBranchService branchService, IBankService bankService, IQuotationService quotationService
            )
        {
            _cityService = cityService;
            _cityWebDataService = cityWebDataService;
            _currencyService = currencyService;
            _currencyWebDataService = currencyWebDataService;
            _webDataService = webDataService;
            _dataParserRepository = dataParserRepository;
            _branchService = branchService;
            _bankService = bankService;
            _quotationService = quotationService;
        }

        public void Start()
        {
            var cities =  _cityWebDataService.GetData(selector: ".//*/li/select/option", url: @"https://m.select.by/kurs");
            foreach (var city in cities) _cityService.Add(city);

            var currencies = _currencyWebDataService.GetData(selector: ".//*/div/select/option", url: @"https://m.select.by/kurs");
            foreach (var currency in currencies) _currencyService.Add(currency);

            var result = GetData(_cityService.GetData(), _currencyService.GetData());
        }


        private IEnumerable<BaseEntityDTO> GetData(IEnumerable<CityDTO> cities, IEnumerable<CurrencyDTO> currencies)
        {
            var result = new List<BaseEntityDTO>();

            foreach (var city in cities)
            {
                foreach (var currency in currencies)
                {
                    var pr = _webDataService.GetData(
                        selector: ".//*/tbody/tr/td/table/tbody/tr/td",
                        url: @"https://select.by" + $"/{city.NameLat}{currency.Url}");
                    foreach (var p in pr)
                    {
                        _bankService.Add(p);

                        _branchService.Add(new BranchDTO
                        {
                            AdrRus = p.Adr,
                            AdrLat = p.Adr
                        });
                        //_quotationService.Add(new QuotationDTO());
                        
                    }

                    //result.AddRange(_webDataService.GetData(
                    //    selector: ".//*/tbody/tr/td/table/tbody/tr/td",
                    //    url: @"https://select.by" + $"/{city.NameLat}{currency.Url}"
                    //)); 
                }
            }
            return result;
        }
    }
}
