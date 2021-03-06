﻿using System.Collections.Generic;
using DataAccess;
using OpenQA.Selenium;
namespace HtmlParse
{
    public class CurrenciesParserRepository : ICurrenciesParserRepository
    {
        public IEnumerable<Currency> GetCurrencies(string selector, string url)
        {
            using (var parseData = new GenericRepository(url))
            {
                var dataWebElements = parseData.GetDataList(By.XPath(selector));

                var resultCurrencies = new List<Currency>();

                for (int i = 1; i < dataWebElements.Count; i++)
                {
                    var nameLat = dataWebElements[i].Text.Split(' ')[0];
                    var nameRus = dataWebElements[i].Text.TrimStart(nameLat.ToCharArray());

                    resultCurrencies.Add(new Currency
                    {
                        NameLat = nameLat,
                        NameRus = nameRus,
                        Url = dataWebElements[i].GetAttribute("value")
                    });
                }
                return resultCurrencies;
            }
        }
    }
}
