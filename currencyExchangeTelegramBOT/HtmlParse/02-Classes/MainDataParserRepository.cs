using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlParse
{
    public class MainDataParserRepository : IMainDataParserRepository
    {
        private IWebDriver _driver;

        public IEnumerable<IEnumerable<string>> GetData(string selector, string url)
        {
            using (_driver = new ChromeDriver() { Url = url })
            {
                ClickAllButtons(By.ClassName("expand"));
                var currencyData = GetWebElements(By.XPath(selector));
                return DropData(currencyData).Select(ParseData).ToList();
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


        private void ClickAllButtons(By selector)
        {
            var buttons = GetWebElements(By.ClassName("expand"));
            foreach (var btn in buttons)
            {
                Thread.Sleep(200);
                btn.Click();
            }
        }

        private IReadOnlyCollection<IWebElement> GetWebElements(By selector) => 
            _driver.FindElements(selector);

    }
}
