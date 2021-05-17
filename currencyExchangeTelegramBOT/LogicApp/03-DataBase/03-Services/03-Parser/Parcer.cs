using System.Linq;

namespace BusinessLogic
{
    public class Parser
    {
        private readonly ICityService _cityService;
        private readonly ICityWebDataService _cityWebDataService;

        private readonly ICurrencyService _currencyService;
        private readonly ICurrencyWebDataService _currencyWebDataService;

        //private readonly IWebDataService _webDataService;

        //private readonly IBranchService _branchService;
        //private readonly IBankService _bankService;
        //private readonly IQuotationService _quotationService;


        public Parser(ICityService cityService, ICityWebDataService cityWebDataService,
            ICurrencyService currencyService, ICurrencyWebDataService currencyWebDataService
            //IWebDataService webDataService, IMainDataParserRepository dataParserRepository,
            //IBranchService branchService, IBankService bankService, IQuotationService quotationService
            )
        {
            _cityService = cityService;
            _cityWebDataService = cityWebDataService;

            _currencyService = currencyService;
            _currencyWebDataService = currencyWebDataService;

            //_webDataService = webDataService;

            //_branchService = branchService;
            //_bankService = bankService;
            //_quotationService = quotationService;
        }

        public void Start()
        {
            var cities =  _cityWebDataService.GetData(selector: ".//*/li/select/option", url: @"https://m.select.by/kurs");
            foreach (var city in cities)
            {
                if (_cityService.GetData().Any(a=>a.Key == city.Key)) _cityService.Update(city);
                else _cityService.Add(city);
            }

            var currencies = _currencyWebDataService.GetData(".//*/div/select/option");
            foreach (var currency in currencies)
            {
                if (_currencyService.GetData().Any(a => a.Key == currency.Key)) _currencyService.Update(currency);
                else _currencyService.Add(currency);
            }

            //GetData(_cityService.GetData(), _currencyService.GetData());
        }

        //private void GetData(IEnumerable<CityDTO> cities, IEnumerable<CurrencyDTO> currencies)
        //{
        //    foreach (var city in cities)
        //    {
        //        foreach (var currency in currencies) 
        //            _webDataService.GetData(selector:".//*/tbody/tr/td/table/tbody/tr/td", 
        //                url:@"https://select.by" + $"/{city.NameLat}{currency.Url}");
        //    }
        //}
    }
}
