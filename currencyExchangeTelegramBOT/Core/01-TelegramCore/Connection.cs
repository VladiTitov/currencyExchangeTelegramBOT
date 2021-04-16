using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using LogicApp;
using LogicApp._01_Buttons;
using LogicApp._02_MenuBot;
using Telegram.Bot.Types.Enums;

namespace Core._01_TelegramCore
{
    class Connection
    {
        private string Token;

        private static ITelegramBotClient botClient;
        private static IReplyMarkup _markup;

        public Connection(string token) => Token = token;
       
        public void Start()
        {
            botClient = new TelegramBotClient(Token) { Timeout = TimeSpan.FromSeconds(10) };
            User me = botClient.GetMeAsync().Result;

            Console.WriteLine($"{me.Id} and {me.FirstName} started");

            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();
        }

        

        public async void BotClient_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;

            if (text == null) return;

            ArchitectureMenu.MenuButtonEvent(new Button(text), out text, out _markup);

            //var betaControl3 = new InlineKeyboardButton() {Text = "test1", CallbackData = "1"};
            //_btnMessage = new InlineKeyboardMarkup(new []{betaControl3});

            await SendMessage(e.Message.Chat, text, _markup);
        }

        private Task SendMessage(Chat chat, string text, IReplyMarkup replyMarkup) => botClient.SendTextMessageAsync(chatId: chat, text: text, 
            ParseMode.Default, true, false, 0, replyMarkup: replyMarkup, CancellationToken.None);
    }
}
