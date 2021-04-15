using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
            List<Bank> banks = new List<Bank>();
            driver.Url = @"https://select.by/kurs-dollara";

            ReadOnlyCollection<IWebElement> buttons = driver.FindElements(By.ClassName("expand"));
            foreach (var btn in buttons) btn.Click();

            Thread.Sleep(1000);

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.ClassName("tablesorter-childRow"));
            foreach (IWebElement e in elements) 
                banks.Add(BankData(DropData(e.FindElements(By.XPath(".//*/tbody/tr/td")))));

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

        private static Bank BankData(List<List<IWebElement>> data)
        {
            string BankName = "";
            List<Branches> brancheses = new List<Branches>();
            foreach (var d in data)
            {
                var Data = ParseData(d);
                BankName = Data.NameBank;
                brancheses.Add(new Branches(Data.AddrBank, Data.BestBuy, Data.BestSale, Data.Phones));
            }

            return new Bank(BankName, 
                brancheses.Select(a => a.BestBuy).Max(), 
                brancheses.Select(a => a.BestSale).Min(), 
                brancheses);
        }

        private static (string NameBank, string AddrBank, string[] Phones, double BestBuy, double BestSale) ParseData(List<IWebElement> elements)
        {
            string[] nameAndAddr = elements[0].FindElement(By.ClassName("btn-tomap")).GetAttribute("data-name").Split(": ");
            string[] phones = elements[0].FindElement(By.ClassName("phones")).Text.Split("\r\n");

            return (nameAndAddr[0], nameAndAddr[1], phones, Convert.ToDouble(elements[1].Text), Convert.ToDouble(elements[2].Text));
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
        public List<Branches> Brancheses { get; set; }

        public Bank(string name, double bestBuy, double bestSale, List<Branches> brancheses) : base(name, bestBuy, bestSale) => Brancheses = brancheses;
    }

    class Branches : IBank
    {
        public List<string> Phones { get; set; }

        public Branches(string name, double bestBuy, double bestSale, string[] phones) :
            base(name, bestBuy, bestSale) => Phones = phones.ToList();
    }
}