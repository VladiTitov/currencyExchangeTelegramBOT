using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DataAccess;
using OpenQA.Selenium;

namespace HtmlParse
{
    public class MainDataParserRepository : IMainDataParserRepository
    {
        public IEnumerable<BaseEntityClass> GetData(string selector, string url)
        {
            using (var parseData = new GenericRepository(url))
            {
                var buttons = parseData.GetDataList(By.ClassName("expand"));
                foreach (var btn in buttons)
                {
                    btn.Click();
                    Thread.Sleep(300);
                }

                var data = parseData.GetDataList(By.XPath(selector));
                var dropData = DropData(data);
                var result = dropData.Select(ParseData).ToList();
                return result;
            }
        }

        private static BaseEntityClass ParseData(List<IWebElement> elements)
        {
            string[] nameAndAdr = elements[0].FindElement(By.ClassName("btn-tomap")).GetAttribute("data-name").Split(": ");
            string _phones = elements[0].FindElement(By.ClassName("phones")).Text;
            string _bankName = nameAndAdr[0];
            string _adr = nameAndAdr[1];
            string _bestBuy = elements[1].Text;
            string _bestSale = elements[2].Text;

            return new BaseEntityClass(_bankName, _adr, _phones, _bestBuy, _bestSale);
        }

        private static IEnumerable<List<IWebElement>> DropData(IReadOnlyCollection<IWebElement> data)
        {
            return Enumerable.Range(0, data.Count / 3)
                .Select(i => data.Skip(i * 3)
                    .Take(3)
                    .ToList())
                .ToList();
        }
    }
}
