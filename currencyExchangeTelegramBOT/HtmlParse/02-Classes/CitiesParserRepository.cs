﻿using System.Collections.Generic;
using DataAccess;
using OpenQA.Selenium;

namespace HtmlParse
{
    public class CitiesParserRepository : ICitiesParserRepository
    {
        public IEnumerable<City> GetCities(string selector, string url)
        {
            using (var parserData = new GenericRepository())
            {
                var dataWebElements = parserData.GetData(By.XPath(selector), url);
                var resultCities = new List<City>();

                for (int i = 1; i < dataWebElements.Count; i++)
                {
                    var tempUrl = dataWebElements[i].GetAttribute("value");
                    var nameLat = GetNameLatCity(tempUrl);
                    var nameRus = dataWebElements[i].Text;

                    resultCities.Add(new City()
                    {
                        Key = nameLat,
                        NameLat = nameLat,
                        NameRus = nameRus,
                        Url = tempUrl
                    });
                }
                return resultCities;
            }
        }

        private string GetNameLatCity(string url)
        {
            string tempName = url.Split('/')[1];
            char firstChar = tempName[0];
            return $"{firstChar.ToString().ToUpper()}{tempName.TrimStart(firstChar)}";
        }
    }
}
