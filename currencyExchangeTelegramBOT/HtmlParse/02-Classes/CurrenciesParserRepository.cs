using System.Collections.Generic;
using DataAccess;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlParse
{
    public class CurrenciesParserRepository : ICurrenciesParserRepository
    {

        public IEnumerable<Currency> GetData(string selector, string resource)
        {
            using (IWebDriver driver = new ChromeDriver() { Url = resource })
            {
                var values = driver.FindElements(By.XPath(selector));
                var resultCurrencies = GetCurrencies(values);
                return resultCurrencies;
            }
        }

        private IEnumerable<Currency> GetCurrencies(IReadOnlyList<IWebElement> dataWebElements)
        {
            var resultCurrencies = new List<Currency>();

            for (int i = 1; i < dataWebElements.Count; i++)
            {
                var nameLat = dataWebElements[i].Text.Split(' ')[0];
                var nameRus = dataWebElements[i].Text.TrimStart(nameLat.ToCharArray());

                resultCurrencies.Add(new Currency()
                {
                    Key = nameLat,
                    NameLat = nameLat,
                    NameRus = nameRus,
                    Url = dataWebElements[i].GetAttribute("value")
                });
            }

            return resultCurrencies;
        }
    }
}
