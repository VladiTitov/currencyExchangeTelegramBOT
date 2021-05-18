using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace HtmlParse
{
    public class MainDataParserRepository : IMainDataParserRepository
    {
        public IEnumerable<IEnumerable<string>> GetData(string selector, string url)
        {
            using (var parseData = new GenericRepository(url))
            {
                var buttons = parseData.GetDataList(By.ClassName("expand"));
                foreach (var btn in buttons)
                {
                    btn.Click();
                    Thread.Sleep(300);
                }

                IReadOnlyList<IWebElement> data = parseData.GetDataList(By.XPath(selector));
                var dropData = DropData(data);
                var result = dropData.Select(ParseData).ToList();
                return result;
            }
        }

        private static List<string> ParseData(List<IWebElement> elements)
        {
            string[] nameAndAdr = elements[0].FindElement(By.ClassName("btn-tomap")).GetAttribute("data-name").Split(": ");
            string phones = elements[0].FindElement(By.ClassName("phones")).Text;
            string bankName = nameAndAdr[0];
            string adr = nameAndAdr[1];
            string bestBuy = elements[1].Text;
            string bestSale = elements[2].Text;

            return new List<string>() { phones, bankName, adr, bestBuy, bestSale };
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
