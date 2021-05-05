using System;
using FluentScheduler;
using LogicApp;

namespace Core
{
    internal static class Core
    {
        private static void Main()
        {
            var connection = new Connection("1401702551:AAHrr7hEYPKXLXdLgvI6zWYsxgzA-Ra24ms");
            JobManager.Initialize(new ParserDataTask());
            connection.Start();

            Console.ReadLine();
        }
    }
}
