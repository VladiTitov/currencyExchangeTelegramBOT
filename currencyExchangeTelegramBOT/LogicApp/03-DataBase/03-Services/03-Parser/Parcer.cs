using System.Collections.Generic;
using System.Linq;
using HtmlParse;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BusinessLogic
{
    public class Parser
    {
        private readonly ICityService _cityService;
        private readonly ICityWebDataService _cityWebDataService;
        
        private readonly IBranchService _branchService;
        private readonly IBankService _bankService;
        private readonly ICurrencyService _currencyService;
        private readonly IQuotationService _quotationService;


        public Parser(ICityService cityService, ICityWebDataService cityWebDataService, IBranchService branchService, IBankService bankService, ICurrencyService currencyService,             IQuotationService quotationService)
        {
            _cityService = cityService;
            _cityWebDataService = cityWebDataService;
            _branchService = branchService;
            _bankService = bankService;
            _currencyService = currencyService;
            _quotationService = quotationService;
        }

        public void Start()
        {
            var cities =  _cityWebDataService.GetData(".//*/li/select/option");
            foreach (var city in cities)
            {
                if (_cityService.GetData().Any(a=>a.Key == city.Key)) _cityService.Update(city);
                else _cityService.Add(city);
            }


            //foreach (var city in _cities)
            //{
            //    foreach (var currency in _currencies)
            //    {
            //        string url = $"/{city.NameLat}{currency.Url}";
            //        List<SiteData> data = ParseData<SiteData>(url);
            //        ReturnBanks(data, city);
            //        ReturnCurrencies(currency, data);
            //    }
            //}
        }

        //private void ReturnBanks(List<SiteData> data, City city)
        //{
        //    foreach (var d in data)
        //    {
        //        if (_banks.All(a => a.NameRus != d.Bank))
        //            _banks.Add(new Bank()
        //            {
        //                Key = $"Bank_{_banks.Count()}",
        //                NameLat = d.Bank,
        //                NameRus = d.Bank
        //            });
        //        if (_branches.All(a => a.AdrRus != d.Adr))
        //            _branches.Add(new Branches()
        //            {
        //                Key = $"Branch_{_branches.Count}",
        //                AdrLat = d.Adr,
        //                AdrRus = d.Adr,
        //                Phones = d.Phone
        //            });
        //    }
        //}

        //private void ReturnCurrencies(Currency currency, List<SiteData> data)
        //{
        //    List<Quotation> quotations = new List<Quotation>();
        //    foreach (var d in data)
        //    {
        //        quotations.Add(new Quotation()
        //        {
        //            Key = $"{d.Bank}-{currency.NameLat}-{quotations.Count()}",
        //            Buy = d.Buy,
        //            Sale = d.Sale
        //        });
        //    }
        //    new DataActions().Add(quotations);
        //}
    }
}
