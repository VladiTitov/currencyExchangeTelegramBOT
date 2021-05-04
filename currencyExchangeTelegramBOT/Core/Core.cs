using System;

namespace Core
{
    internal static class Core
    {
        private static void Main(string[] args)
        {
            var connection = new Connection("1401702551:AAHrr7hEYPKXLXdLgvI6zWYsxgzA-Ra24ms");
            //new DataBaseService().Start();
            connection.Start();

            Console.ReadLine();
        }
    }
}
