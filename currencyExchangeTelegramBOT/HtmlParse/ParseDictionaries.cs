using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;

namespace HtmlParse
{
    public class ParseDictionaries
    {
        private readonly IWebDriver _driver;

        public ParseDictionaries(IWebDriver driver) => _driver = driver;

        public List<T> GeParseData<T>()
        {
            return typeof(T).Name switch
            {
                "Currency" => ReturnListValues<T>(".//*/div/select/option"),
                "City" => ReturnListValues<T>(".//*/li/select/option"),
            };
        }

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
    }
}
