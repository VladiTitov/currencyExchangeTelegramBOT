using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Banks._02_Classes;
using HtmlParse;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SqlLiteData;
using FluentScheduler;

namespace Core._01_TelegramCore
{
    public class DataBaseService
    {
        private string ConnectionString { get; set; } = "Data Source=../data.db";

        public void Start()
        {
            List<Currency> currencies = new List<Currency>();

            try
            {
                currencies = new CurrencyRepo(ConnectionString).GetCurrencies();
            }
            catch
            {
                ParseData<Currency>("/kurs");
            }

            if (currencies.Count() == 0) ParseData<Currency>("/kurs");

            foreach (Currency c in currencies)
            {
                ParseData<Branches>(c.Url);
            }
        }

        public void ParseData<T>(string partUrl)
        {
            List<T> data = new List<T>();

            using (IWebDriver driver = new ChromeDriver())
            {
                string Url = @"https://m.select.by" + $"{partUrl}";
                driver.Url = Url;
                switch (typeof(T).Name)
                {
                    case "City":
                        List<City> cities = new WebSiteData(driver).GetCities();
                        break;
                    case "Currency":
                        List<Currency> currencies = new WebSiteData(driver).GetCurrencies();
                        new CurrencyRepo(ConnectionString).Add(currencies);
                        break;
                    case "Branches":
                        List<Branches> branches = new WebSiteData(driver).GetData();
                        break;
                }
                driver.Close();
            }
        }

        
    }

    public class DataTask : Registry
    {
        public DataTask()
        {
            Schedule(() => new DataBaseService().Start()).ToRunEvery(10).Minutes();
        }
    }
}
