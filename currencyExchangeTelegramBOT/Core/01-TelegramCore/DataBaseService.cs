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
                currencies = new ITableModel<Currency>(ConnectionString, "").GetData();
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

        private void CheckTables()
        {

        }

        public List<T> ParseData<T>(string partUrl)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Url = @"https://m.select.by" + $"{partUrl}";
                List<T> resultData = new WebSiteData(driver).GeParseData<T>();
                driver.Close();
                return resultData;
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
