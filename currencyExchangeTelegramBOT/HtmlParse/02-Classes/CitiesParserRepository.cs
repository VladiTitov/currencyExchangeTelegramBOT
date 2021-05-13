using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataAccess;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlParse
{
    public class CitiesParserRepository : ICitiesParserRepository
    {
        public IEnumerable<City> GetData(string key, string resource)
        {
            var data = new List<City>();

            using (IWebDriver driver = new ChromeDriver() { Url = resource })
            {
                ReadOnlyCollection<IWebElement> values = driver.FindElements(By.XPath(key));
                for (int i = 1; i < values.Count; i++)
                {
                    var url = values[i].GetAttribute("value");
                    var nameLat = GetNameLatCity(url);
                    var nameRus = values[i].Text;

                    data.Add(new City()
                    {
                        Key = i.ToString(),
                        NameLat = nameLat,
                        NameRus = nameRus,
                        Url = url
                    });
                }
            }
            return data;
        }

        private string GetNameLatCity(string url)
        {
            string tempName = url.Split('/')[1];
            char firstChar = tempName[0];
            return $"{firstChar.ToString().ToUpper()}{tempName.TrimStart(firstChar)}";
        }
    }
}
