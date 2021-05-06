using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Banks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Banks._02_Classes;

namespace HtmlParse
{
    public class WebSiteData
    {
        private readonly IWebDriver _driver;
        public WebSiteData(IWebDriver driver) => _driver = driver;

        private Currency _currency;
        private City _city;

        public List<T> GeParseData<T>()
        {
            return typeof(T).Name switch
            {
                "Currency" => ReturnListValues<T>(".//*/div/select/option"),
                "City" => ReturnListValues<T>(".//*/li/select/option")
            };
        }

        public List<T> GetData<T>(City city, Currency currency)
        {
            _city = city;
            _currency = currency;

            List<T> brancheses = new List<T>();

            #region Нажимаем на все кнопки чтобы активировать скрипты

            ReadOnlyCollection<IWebElement> buttons = _driver.FindElements(By.ClassName("expand"));
            foreach (var btn in buttons)
            {
                Thread.Sleep(200);
                btn.Click();
            }

            #endregion

            ReadOnlyCollection<IWebElement> elements = _driver.FindElements(By.ClassName("tablesorter-childRow"));
            foreach (IWebElement e in elements)
            {
                ReadOnlyCollection<IWebElement> data = e.FindElements(By.XPath(".//*/tbody/tr/td"));
                List<List<IWebElement>> elementsList = DropData(data);
                brancheses.AddRange(BankData<T>(elementsList));
            }
            return brancheses;
        }

        #region Возвращает словари (Города и Валюты)

        private List<T> ReturnListValues<T>(string xPath)
        {
            List<T> result = new List<T>();
            ReadOnlyCollection<IWebElement> values = _driver.FindElements(By.XPath(xPath));
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

        #endregion

        private List<List<IWebElement>> DropData(ReadOnlyCollection<IWebElement> data)
        {
            return Enumerable.Range(0, data.Count / 3)
                .Select(i => data.Skip(i * 3)
                    .Take(3)
                    .ToList())
                .ToList();
        }

        private List<T> BankData<T>(List<List<IWebElement>> data)
        {
            List<T> result = new List<T>();
            foreach (var _data in data)
            {
                result.Add(ParseData<T>(_data));
            }
            return result;
        }

        private T ParseData<T>(List<IWebElement> elements)
        {
            string[] nameAndAddr = elements[0].FindElement(By.ClassName("btn-tomap")).GetAttribute("data-name").Split(": ");

            string key = $"{nameAndAddr[0]}-{new Random().Next(1, 8000)}";
            Branches branches = new Branches()
            {
                AdrLat = nameAndAddr[1],
                AdrRus = nameAndAddr[1],
                BankName = new Bank()
                {
                    Key = key,
                    NameLat = nameAndAddr[0],
                    NameRus = nameAndAddr[0]
                },
                CityName = new City()
                {
                    Key = key,
                    NameLat = "NameLat",
                    NameRus = "NameRus",
                    Url = ""
                },
                Key = key,
                Phones = ""
            };
            string addr = nameAndAddr[1];
            string bestBuy = elements[1].Text;
            string bestSale = elements[2].Text;

            return (T)Activator.CreateInstance(typeof(T), new object[]
            {
                key,
                branches,
                bestSale,
                bestBuy
            });



        }

    }


}
