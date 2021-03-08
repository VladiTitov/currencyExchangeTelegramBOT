using System.Collections.Generic;
using System;
using System.Net;
using System.IO;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Core._01_TelegramCore;

namespace Core
{
    class Core
    {
        static void Main(string[] args)
        {
            Connection connection = new Connection("1401702551:AAHrr7hEYPKXLXdLgvI6zWYsxgzA-Ra24ms");
            connection.Start();

            Console.ReadLine();
        }
    }
}
