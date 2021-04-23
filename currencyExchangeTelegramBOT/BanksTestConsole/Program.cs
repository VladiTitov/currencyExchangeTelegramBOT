using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BanksTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //USD = https://select.by/kurs-dollara
            //EUR = https://select.by/kurs-evro
            //RUB = https://select.by/kurs-rublya

            IWebDriver driver = new ChromeDriver();
            driver.Url = @"https://select.by/kurs-dollara";

            ReadOnlyCollection<IWebElement> buttons = driver.FindElements(By.ClassName("expand"));
            foreach (var btn in buttons) btn.Click();

            Thread.Sleep(1000);

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.ClassName("tablesorter-childRow"));
            foreach (IWebElement e in elements)
            {
                var element = e.FindElements(By.XPath(".//*/tbody/tr/td"));
                var dropElement = DropData(element);
                var allBankBransches = BankData(dropElement);
            }

            driver.Close();
            Console.ReadLine();
        } 

        private static List<List<IWebElement>> DropData(ReadOnlyCollection<IWebElement> data)
        {
            return Enumerable.Range(0, data.Count / 3)
                .Select(i => data.Skip(i * 3)
                    .Take(3)
                    .ToList())
                .ToList();
        }

        private static List<Branches> BankData(List<List<IWebElement>> data)
        {
            List<Branches> brancheses = new List<Branches>();
            foreach (var d in data) brancheses.Add(ParseDataNew(d));
            return brancheses;
        }

        private static Branches ParseDataNew(List<IWebElement> elements)
        {
            string[] nameAndAddr = elements[0].FindElement(By.ClassName("btn-tomap")).GetAttribute("data-name").Split(": ");
            string[] phones = elements[0].FindElement(By.ClassName("phones")).Text.Split("\r\n");
            return new Branches(nameAndAddr[1], Convert.ToDouble(elements[1].Text), Convert.ToDouble(elements[2].Text), phones);
        }

    }

    abstract class IBank
    {
        public IBank(string name, double bestBuy, double bestSale)
        {
            Name = name;
            BestBuy = bestBuy;
            BestSale = bestSale;
        }

        public string Name { get; set; }
        public double BestBuy { get; set; }
        public double BestSale { get; set; }
    }

    class Bank : IBank
    {
        private List<Branches> Brancheses { get; set; }

        public Bank(string name, double bestBuy, double bestSale, List<Branches> brancheses) : base(name, bestBuy, bestSale) => Brancheses = brancheses;
    }

    class Branches : IBank
    {
        public List<string> Phones { get; set; }

        public Branches(string name, double bestBuy, double bestSale, IEnumerable<string> phones) :
            base(name, bestBuy, bestSale) => Phones = phones.ToList();
    }
}