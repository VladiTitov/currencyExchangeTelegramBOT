using System.Collections.Generic;
using System.Data;
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
            new DataActions().Add(ParseData<City>("/kurs"));
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
