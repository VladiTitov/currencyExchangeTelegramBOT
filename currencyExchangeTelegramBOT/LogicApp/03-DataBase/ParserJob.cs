using System.Collections.Generic;
using System.Data;
using System.Linq;
using Banks;
using Banks._02_Classes;
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
        public void Start()
        {
            var cities = ParseData<City>("/kurs");
            var currencies = ParseData<Currency>("/kurs");

            foreach (var city in cities)
            {
                foreach (var currency in currencies)
                {
                    string url = $"/{city.NameLat}{currency.Url}";
                    var data = ParseData<Quotation>(url);
                    new DataActions().Add(data);
                }
            }
        }

        private List<T> ParseData<T>(string partUrl)
        {
            using IWebDriver driver = new ChromeDriver
            {
                Url = @"https://m.select.by" + $"{partUrl}"
            };
            var resultData = new WebSiteData(driver).GeParseData<T>();
            driver.Close();
            return resultData;
        }
    }
}
