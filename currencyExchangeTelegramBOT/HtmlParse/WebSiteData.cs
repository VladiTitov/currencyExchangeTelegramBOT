using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlParse
{
    public class WebSiteData
    {
        private readonly IWebDriver _driver;
        public WebSiteData(IWebDriver driver) => _driver = driver;

        public List<T> GetData<T>()
        {
            List<T> branches = new List<T>();

            #region Нажимаем на все кнопки чтобы активировать скрипты

            ReadOnlyCollection<IWebElement> buttons = _driver.FindElements(By.ClassName("expand"));
            foreach (var btn in buttons)
            {
                Thread.Sleep(200);
                btn.Click();
            }

            #endregion

            ReadOnlyCollection<IWebElement> elements = _driver.FindElements(By.ClassName("tablesorter-childRow"));
            foreach (var e in elements)
            {
                var data = e.FindElements(By.XPath(".//*/tbody/tr/td"));
                var elementsList = DropData(data);
                branches.AddRange(BankData<T>(elementsList));
            }
            return branches;
        }

        private IEnumerable<List<IWebElement>> DropData(IReadOnlyCollection<IWebElement> data)
        {
            return Enumerable.Range(0, data.Count / 3)
                .Select(i => data.Skip(i * 3)
                    .Take(3)
                    .ToList())
                .ToList();
        }

        private List<T> BankData<T>(IEnumerable<List<IWebElement>> data) => 
            data.Select(ParseData<T>).ToList();


        private T ParseData<T>(List<IWebElement> elements)
        {
            string[] nameAndAddr = elements[0].FindElement(By.ClassName("btn-tomap")).GetAttribute("data-name").Split(": ");
            string bank = nameAndAddr[0];
            string adr = nameAndAddr[1];
            string bestBuy = elements[1].Text;
            string bestSale = elements[2].Text;

            return (T)Activator.CreateInstance(typeof(T), new object[]
            {
                bank,
                adr,
                "phone",
                bestSale,
                bestBuy
            });



        }

    }


}
