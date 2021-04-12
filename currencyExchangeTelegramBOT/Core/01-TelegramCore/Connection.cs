using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using LogicApp;
using LogicApp._01_Buttons;

namespace Core._01_TelegramCore
{
    class Connection
    {
        private string Token;

        private static ITelegramBotClient botClient;
        private static ReplyKeyboardMarkup _keyboard;

        public Connection(string token) => Token = token;
       
        public void Start()
        {
            botClient = new TelegramBotClient(Token) { Timeout = TimeSpan.FromSeconds(10) };
            var me = botClient.GetMeAsync().Result;

            Console.WriteLine($"{me.Id} and {me.FirstName} started");

            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();
        }

        public async void BotClient_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;

            if (text == null) return;

            new Button(text).ReturnButtons(out text, out _keyboard);

            //new Buttons().ReturnAnswer(text, out text, out _keyboard);

            await botClient.SendTextMessageAsync(chatId: e.Message.Chat, text: text, replyMarkup: _keyboard).ConfigureAwait(false);
        }
    }
}
