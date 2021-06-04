using System;
using AutoMapper.Configuration.Annotations;
using BusinessLogic;
using FluentScheduler;
using OpenQA.Selenium.Chrome;

namespace Core
{
    class Core
    {
        static void Main(string[] args)
        {
            var connection = new Connection("1401702551:AAHrr7hEYPKXLXdLgvI6zWYsxgzA-Ra24ms");
            JobManager.Initialize(new ParserDataTask());
            connection.Start();

            Console.ReadLine();
        }
    }
}
