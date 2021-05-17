using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlParse
{
    public class GenericRepository : IGenericRepository, IDisposable
    {
        private IWebDriver _driver;

        public void Dispose() =>
            _driver.Close();

        public IReadOnlyList<IWebElement> GetData(By selector, string url)
        {
           _driver = new ChromeDriver() { Url = url };
           return _driver.FindElements(selector);
        }
    }
}
