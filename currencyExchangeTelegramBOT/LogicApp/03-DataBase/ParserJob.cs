using System.Collections.Generic;
using FluentScheduler;
using HtmlParse;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            //Task

            //Обновить словари (города, валюты)



            //Отпарсить все валюты

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
