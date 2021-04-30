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
            Connection connection = new Connection("1401702551:AAHrr7hEYPKXLXdLgvI6zWYsxgzA-Ra24ms");
            new DataBaseService().Start();
            connection.Start();

            Console.ReadLine();
        }
    }
}
