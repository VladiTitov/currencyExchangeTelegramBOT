using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlParse
{
    class WebSiteData
    {
        //USD = https://select.by/kurs-dollara
        //EUR = https://select.by/kurs-evro
        //RUB = https://select.by/kurs-rublya

        IWebDriver driver = new ChromeDriver();

        public WebSiteData(string part) => driver.Url = @"https://select.by/kurs-" + $"{part}";

        public void GetData()
        {
            var buttons = driver.FindElements(By.ClassName("expand"));
            foreach (var btn in buttons) btn.Click();
            Thread.Sleep(1000);
            var hasChildRow = driver.FindElements(By.ClassName("tablesorter-hasChildRow"));


            var childRow = driver.FindElements(By.ClassName("tablesorter-childRow"));
            foreach (IWebElement e in childRow)
            {
                string data1 = e.Text;
                data1 = e.GetAttribute("data-name");
            }

            driver.Close();
        }

        private void ReturnData(ReadOnlyCollection<IWebElement> bestDeal, ReadOnlyCollection<IWebElement> branches)
        {
            
        }

    }

    
}
