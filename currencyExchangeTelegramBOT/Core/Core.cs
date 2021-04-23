using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Core._01_TelegramCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Banks._02_Classes;
using HtmlParse;

namespace Core
{
    class Core
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection("1401702551:AAHrr7hEYPKXLXdLgvI6zWYsxgzA-Ra24ms");
            connection.Start();

            //IWebDriver driver = new ChromeDriver() { Url = @"https://m.select.by/kurs-dollara" };
            IWebDriver driver = new ChromeDriver() { Url = @"https://select.by/kurs" };
            new WebSiteData(driver).GetData();

            Console.ReadLine();
        }
    }
}
