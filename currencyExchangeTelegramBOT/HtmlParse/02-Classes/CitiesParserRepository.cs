using System.Collections.Generic;
using DataAccess;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlParse
{
    public class CitiesParserRepository : ICitiesParserRepository
    {
        public IEnumerable<City> GetData(string selector, string resource)
        {
            using (IWebDriver driver = new ChromeDriver() { Url = resource })
            {
                var values = driver.FindElements(By.XPath(selector));
                var resultCities = GetCities(values);
                return resultCities;
            }
        }

        private IEnumerable<City> GetCities(IReadOnlyList<IWebElement> dataWebElements)
        {
            var resultCities = new List<City>();

            for (int i = 1; i < dataWebElements.Count; i++)
            {
                var url = dataWebElements[i].GetAttribute("value");
                var nameLat = GetNameLatCity(url);
                var nameRus = dataWebElements[i].Text;

                resultCities.Add(new City()
                {
                    Key = nameLat,
                    NameLat = nameLat,
                    NameRus = nameRus,
                    Url = url
                });
            }
            return resultCities;
        }

        private string GetNameLatCity(string url)
        {
            string tempName = url.Split('/')[1];
            char firstChar = tempName[0];
            return $"{firstChar.ToString().ToUpper()}{tempName.TrimStart(firstChar)}";
        }
    }
}
