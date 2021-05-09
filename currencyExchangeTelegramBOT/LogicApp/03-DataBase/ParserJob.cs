using System.Collections.Generic;
using System.Data;
using System.Linq;
using Banks;
using FluentScheduler;
using HtmlParse;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SqlLiteData;

namespace LogicApp
{
    public class ParserJob : IJob
    {
        public void Execute() =>
            new Parser().Start();
    }

    public class Parser
    {
        private List<City> _cities;
        private List<Currency> _currencies;
        private List<Bank> _banks { get; set; } = new List<Bank>();
        private List<Branches> _branches { get; set; } = new List<Branches>();


        public void Start()
        {
            _cities = ParseData<City>("/kurs");
            _currencies = ParseData<Currency>("/kurs");

            foreach (var city in _cities)
            {
                foreach (var currency in _currencies)
                {
                    string url = $"/{city.NameLat}{currency.Url}";
                    List<SiteData> data = ParseData<SiteData>(url);
                    ReturnBanks(data, city);
                    ReturnCurrencies(currency, data);
                }
            }
        }

        private List<T> ParseData<T>(string partUrl)
        {
            using IWebDriver driver = new ChromeDriver { Url = @"https://m.select.by" + $"{partUrl}" };
            var resultData = new ParseDictionaries(driver).GeParseData<T>();
            driver.Close();
            return resultData;
        }

        private void ReturnBanks(List<SiteData> data, City city)
        {
            foreach (var d in data)
            {
                if (_banks.All(a => a.NameRus != d.Bank)) 
                    _banks.Add(new Bank()
                    {
                        Key = $"Bank_{_banks.Count()}",
                        NameLat = d.Bank,
                        NameRus = d.Bank
                    });
                if (_branches.All(a=> a.AdrRus != d.Adr))
                    _branches.Add(new Branches()
                    {
                        Key = $"Branch_{_branches.Count}",
                        AdrLat = d.Adr,
                        AdrRus = d.Adr,
                        Phones = d.Phone
                    });
            }
        }

        private void ReturnCurrencies(Currency currency, List<SiteData> data)
        {
            List<Quotation> quotations = new List<Quotation>();
            foreach (var d in data)
            {
                quotations.Add(new Quotation()
                {
                    Key = $"{d.Bank}-{currency.NameLat}-{quotations.Count()}",
                    Buy = d.Buy,
                    Sale = d.Sale
                });
            }
            //new DataActions().Add(quotations);
        }
    }
}
