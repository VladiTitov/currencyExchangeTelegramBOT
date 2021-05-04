using System.Collections.Generic;
using System.Linq;
using Banks._02_Classes;
using FluentScheduler;
using HtmlParse;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SqlLiteData;
using SqlLiteDataAPI;

namespace Core
{
    public class DataBaseService
    {
        private string ConnectionString { get; } = "Data Source=../data.db";

        public void Start()
        {
            List<Currency> currencies = new List<Currency>();

            try
            {
                currencies = new TableModel<Currency>(ConnectionString, "").GetData();
            }
            catch
            {
                ParseData<Currency>("/kurs");
            }

            if (currencies.Count() == 0)
            {
                ParseData<Currency>("/kurs");
            }

            foreach (Currency c in currencies)
            {
                ParseData<Branches>(c.Url);
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

    public class DataTask : Registry
    {
        public DataTask()
        {
            Schedule(() => new DataBaseService().Start()).ToRunEvery(10).Minutes();
        }
    }
}
