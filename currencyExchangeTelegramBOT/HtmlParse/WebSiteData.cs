using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Banks._02_Classes;

namespace HtmlParse
{
    public class WebSiteData
    {
        private IWebDriver Driver { get; }

        public WebSiteData(IWebDriver driver) => Driver = driver;

        public List<Bank> GetData()
        {
            List<Bank> banks = new List<Bank>();
            #region Нажимаем на все кнопки чтобы активировать скрипты

            ReadOnlyCollection<IWebElement> buttons = Driver.FindElements(By.ClassName("expand"));
            foreach (var btn in buttons) btn.Click();
            Thread.Sleep(1000);

            #endregion

            ReadOnlyCollection<IWebElement> elements = Driver.FindElements(By.ClassName("tablesorter-childRow"));
            foreach (IWebElement e in elements)
            {
                var element = e.FindElements(By.XPath(".//*/tbody/tr/td"));
                var dropElement = DropData(element);
                var allBankBransches = BankData(dropElement);
            }

            return banks;
        }

        private static List<List<IWebElement>> DropData(ReadOnlyCollection<IWebElement> data)
        {
            return Enumerable.Range(0, data.Count / 3)
                .Select(i => data.Skip(i * 3)
                    .Take(3)
                    .ToList())
                .ToList();
        }

        private static List<Branches> BankData(List<List<IWebElement>> data)
        {
            List<Branches> brancheses = new List<Branches>();
            foreach (var _data in data)
            {
                brancheses.Add(ParseData(_data));
            }
            return brancheses;
        }

        private static Branches ParseData(List<IWebElement> elements)
        {
            string[] nameAndAddr = elements[0].FindElement(By.ClassName("btn-tomap")).GetAttribute("data-name").Split(": ");
            string[] phones = elements[0].FindElement(By.ClassName("phones")).Text.Split("\r\n");
            return new Branches(nameAndAddr[1], Convert.ToDouble(elements[1].Text), Convert.ToDouble(elements[2].Text), phones);
        }

    }

    
}
