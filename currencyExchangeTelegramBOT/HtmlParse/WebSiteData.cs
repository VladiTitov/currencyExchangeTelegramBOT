using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            #region Нажимаем на все кнопки чтобы активировать скрипты

            ReadOnlyCollection<IWebElement> buttons = driver.FindElements(By.ClassName("expand"));
            foreach (var btn in buttons) btn.Click();
            Thread.Sleep(1000);

            #endregion

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.ClassName("tablesorter-childRow"));
            foreach (IWebElement e in elements) ReturnData(e.FindElements(By.XPath(".//*/tbody/tr/td")));

            driver.Close();
        }

        private static List<List<IWebElement>> ReturnData(ReadOnlyCollection<IWebElement> data)
        {
            return Enumerable.Range(0, data.Count / 3)
                .Select(i => data.Skip(i * 3)
                    .Take(3)
                    .ToList())
                .ToList();
        }

    }

    
}
