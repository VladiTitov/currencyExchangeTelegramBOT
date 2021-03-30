using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
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

            List<string> Addr = new List<string>();

            IWebDriver driver = new ChromeDriver();
            driver.Url = @"https://select.by/kurs-dollara";

            var buttons = driver.FindElements(By.ClassName("expand"));
            foreach (var btn in buttons) btn.Click();

            var hasChildRow = driver.FindElements(By.ClassName("tablesorter-hasChildRow"));
            var childRow = driver.FindElements(By.ClassName("tablesorter-childRow"));

            for (int i = 0; i < hasChildRow.Count; i++)
            {
                Bank BankInfo = BankData(hasChildRow[i].Text.Replace(" Банк","-Банк"), childRow[i].Text);
                Console.WriteLine($"--------------------------\n\r" +
                                  $"{BankInfo.Name}" +
                                  $"\n\r--------------------------\n\r" +
                                  $"        Покупка:{BankInfo.BestBuy}\n\r" +
                                  $"        Продажа:{BankInfo.BestSale}");
            }

            driver.Close();
            Console.ReadLine();

        }

        private static Bank BankData(string firstStr, string secondStr) =>
            new Bank(
                firstStr.Split(' ').ToList(), 
                secondStr.Split("\r\n").ToList()
                );
    }

    class Bank
    {
        public Bank(List<string> bestDeal, List<string> branches)
        {
            Name = bestDeal[0];
            BestBuy = bestDeal[2];
            BestSale = bestDeal[3];

            //ReturnAddr(branches); 

        }

        private void ReturnAddr(List<string> data)
        {
            data.RemoveRange(0,3);
            foreach (var d in data)
            {
                
            }

        }

        public string Name { get; set; }
        public string BestBuy { get; set; }
        public string BestSale { get; set; }
        public List<Branches> Brancheses { get; set; }

    }

    class Branches
    {
        public Branches(List<string> branches)
        {
            
        }

        public string Addr { get; set; }
        public string Tel { get; set; }
        public string BestBuy { get; set; }
        public string BestSale { get; set; }
    }
}
