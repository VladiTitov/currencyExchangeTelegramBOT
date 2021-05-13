using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataAccess;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlParse
{
    public class CitiesParserRepository : ICitiesParserRepository
    {
        public IEnumerable<City> GetData(string key, string url)
        {
            var data = new List<City>();

            using (IWebDriver driver = new ChromeDriver() { Url = url })
            {
                ReadOnlyCollection<IWebElement> values = driver.FindElements(By.XPath(key));
                for (int i = 1; i < values.Count; i++)
                {
                    string _url = values[i].GetAttribute("value");
                    string _nameLat = GetNameLatCity(_url);
                    string _nameRus = values[i].Text;


                    data.Add(new City()
                    {
                        Key = i.ToString(),
                        NameLat = _nameLat,
                        NameRus = _nameRus,
                        Url = _url
                    });
                }
                //driver.Close();
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
