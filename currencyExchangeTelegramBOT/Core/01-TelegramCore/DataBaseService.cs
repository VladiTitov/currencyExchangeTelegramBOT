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
        public void Start()
        {
            List<Currency> currencies = GetData();
            List<City> cities;

            if (currencies.Count == 0)
            {
                ParseData<Currency>("/kurs");
                this.Start();
            }

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
                        Insert(cities);
                        break;
                    case "Currency":
                        List<Currency> currencies = new WebSiteData(driver).GetCurrencies();
                        Insert(currencies);
                        break;
                    case "Branches":
                        List<Branches> branches = new WebSiteData(driver).GetData();
                        Insert(branches);
                        break;
                }
                driver.Close();
            }
        }

        public void Insert<T>(List<T> data)
        {
            using (DataContext db = new DataContext())
            {
                switch (typeof(T).Name)
                {
                    case "City":
                        db.Cities.AddRange((IEnumerable<City>) data);
                        break;
                    case "Currency":
                        db.Currencies.AddRange((IEnumerable<Currency>)data);
                        break;
                    case "Branches":
                        db.Brancheses.AddRange((IEnumerable<Branches>)data);
                        break;
                }
                db.SaveChanges();
            }
        }

        public void Update<T>(List<T> data)
        {
            using (DataContext db = new DataContext())
            {
                switch (typeof(T).Name)
                {
                    case "City":
                        db.Cities.UpdateRange((IEnumerable<City>)data);
                        break;
                    case "Currency":
                        db.Currencies.UpdateRange((IEnumerable<Currency>)data);
                        break;
                    case "Branches":
                        db.Brancheses.UpdateRange((IEnumerable<Branches>)data);
                        break;
                }
                db.SaveChanges();
            }
        }

        public List<Currency> GetData()
        {
            List<Currency> currencies;
            using (DataContext db = new DataContext())
            {
                currencies = db.Currencies.ToList();
            }
            return currencies;
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
