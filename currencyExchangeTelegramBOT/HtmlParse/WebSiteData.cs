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

        public List<T> GeParseData<T>()
        {
            switch (typeof(T).Name)
            {
                case "Currency":
                    return ReturnListValues<T>(".//*/div/select/option");
                default:
                    return ReturnListValues<T>(".//*/li/select/option");
            }
        }

        public List<Branches> GetData()
        {
            List<Branches> brancheses = new List<Branches>();

            #region Нажимаем на все кнопки чтобы активировать скрипты

            ReadOnlyCollection<IWebElement> buttons = Driver.FindElements(By.ClassName("expand"));
            foreach (var btn in buttons)
            {
                Thread.Sleep(200);
                btn.Click();
            }

            #endregion

            ReadOnlyCollection<IWebElement> elements = Driver.FindElements(By.ClassName("tablesorter-childRow"));
            foreach (IWebElement e in elements)
            {
                ReadOnlyCollection<IWebElement> data = e.FindElements(By.XPath(".//*/tbody/tr/td"));
                List<List<IWebElement>> elementsList = DropData(data);
                brancheses.AddRange(BankData(elementsList));
            }
            return brancheses;
        }

        private List<T> ReturnListValues<T>(string xPath)
        {
            List<T> result = new List<T>();
            ReadOnlyCollection<IWebElement> values = Driver.FindElements(By.XPath(xPath));
            for (int i = 1; i < values.Count; i++)
            {
                result.Add((T)Activator.CreateInstance(typeof(T), new object[]
                {
                    $"{typeof(T).Name}{i}", 
                    "lat", 
                    values[i].Text, 
                    values[i].GetAttribute("value")
                }));
            }

            return result;
        }

        private List<List<IWebElement>> DropData(ReadOnlyCollection<IWebElement> data)
        {
            return Enumerable.Range(0, data.Count / 3)
                .Select(i => data.Skip(i * 3)
                    .Take(3)
                    .ToList())
                .ToList();
        }

        private List<Branches> BankData(List<List<IWebElement>> data)
        {
            List<Branches> brancheses = new List<Branches>();
            foreach (var _data in data)
            {
                brancheses.Add(ParseData(_data));
            }
            return brancheses;
        }

        private Branches ParseData(List<IWebElement> elements)
        {
            string[] nameAndAddr = elements[0].FindElement(By.ClassName("btn-tomap")).GetAttribute("data-name").Split(": ");

            string key = $"{nameAndAddr[0]}-{new Random().Next(1, 8000)}";
            string addr = nameAndAddr[1];
            string bestBuy = elements[1].Text;
            string bestSale = elements[2].Text;
            string phones = "";

            return new Branches(key, addr, bestBuy, bestSale, phones);
        }

    }

    
}
