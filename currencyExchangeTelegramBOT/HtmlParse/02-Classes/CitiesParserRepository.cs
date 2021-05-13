using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataAccess;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlParse
{
    public class CitiesParserRepository : ICitiesParserRepository
    {
        private readonly string _url;

        public CitiesParserRepository(string url) =>
            _url = url;

        public IEnumerable<City> GetData(string key)
        {
            var data = new List<City>();

            //using (IWebDriver driver = new ChromeDriver() {Url = _url})
            //{
            //    ReadOnlyCollection<IWebElement> values = driver.FindElements(By.XPath(key));
            //    for (int i = 1; i < values.Count; i++)
            //    {
            //        string url = values[i].GetAttribute("value");
            //        string nameLat = GetNameLatCity(url);
            //        string nameRus = values[i].Text;


            //        data.Add(new City()
            //        {
            //            Key = i.ToString(),
            //            NameLat = nameLat,
            //            NameRus = nameRus,
            //            Url = url
            //        });
            //    }
            //    driver.Close();
            //}
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
