using System.Collections.Generic;
using System.Linq;
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
                    var data = _webDataService.GetData(
                        selector: ".//*/tbody/tr/td/table/tbody/tr/td",
                        url: @"https://select.by" + $"/{city.NameLat}{currency.Url}");
                    foreach (var d in data)
                    {
                        var (bank, branch, quotation, phone) = GetObjects(d);
                        
                        _bankService.Add(bank);

                        var pr = _bankService.GetWithInclude(bank);

                        //branch.BankDto = tempBank;
                        //branch.CityDto = city;


                        //_branchService.Add(branch);

                        //_bankService.Add(p);
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

        private (BankDTO bank, BranchDTO branch, QuotationDTO quotation, PhoneDTO phone) GetObjects(BaseEntityDTO baseEntity)
        {
            return (
                new BankDTO
                {
                    NameLat = baseEntity.Bank,
                    NameRus = baseEntity.Bank
                },
                new BranchDTO
                {
                    AdrLat = baseEntity.Adr,
                    AdrRus = baseEntity.Adr
                },
                new QuotationDTO
                {
                    Buy = baseEntity.Buy,
                    Sale = baseEntity.Sale
                },
                new PhoneDTO
                {
                    PhoneNum = baseEntity.Phone
                });
        }
    }
}
