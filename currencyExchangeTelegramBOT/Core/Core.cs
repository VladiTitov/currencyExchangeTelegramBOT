using System;
using Core._01_TelegramCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HtmlParse;

namespace Core
{
    class Core
    {
        static void Main(string[] args)
        {
            new DataBaseService().Data();

            Connection connection = new Connection("1401702551:AAHrr7hEYPKXLXdLgvI6zWYsxgzA-Ra24ms");
            connection.Start();
            
            //IWebDriver driver = new ChromeDriver() { Url = @"https://m.select.by/kurs-dollara" };
            IWebDriver driver = new ChromeDriver() { Url = @"https://select.by/kurs" };
            new WebSiteData(driver).GetData();

            Console.ReadLine();
        }
    }
}
