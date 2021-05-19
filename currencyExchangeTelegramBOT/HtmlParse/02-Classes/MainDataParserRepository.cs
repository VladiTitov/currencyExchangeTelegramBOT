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
                    Thread.Sleep(100);
                }

                var data = parseData.GetDataList(By.XPath(selector));
                var dropData = DropData(data);
                return dropData.Select(ParseData).ToList();
            }
        }

        private static BaseEntityClass ParseData(List<IWebElement> elements)
        {
            string[] nameAndAdr = elements[0].FindElement(By.ClassName("btn-tomap")).GetAttribute("data-name").Split(": ");
            string phones = elements[0].FindElement(By.ClassName("phones")).Text;
            string bankName = nameAndAdr[0];
            string adr = nameAndAdr[1];
            string bestBuy = elements[1].Text;
            string bestSale = elements[2].Text;

            return new BaseEntityClass(bankName, adr, phones, bestBuy, bestSale);
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
