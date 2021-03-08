using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

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

            Console.WriteLine($"{me.Id} and {me.FirstName}");

            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();
        }

        public static async void BotClient_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;

            if (text == null) return;

            ReturnAnswer(text, out text, out _keyboard);

            await botClient.SendTextMessageAsync(chatId: e.Message.Chat, text: text, replyMarkup: _keyboard).ConfigureAwait(false);
        }

        public static void ReturnAnswer(string msg, out string message, out ReplyKeyboardMarkup buttons)
        {
            switch (msg)
            {
                case "/start":
                    //BelarusbankClass belarusbank = new BelarusbankClass("https://belarusbank.by/api/kursExchange");
                    //belarusbank.ReturnData();
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>() { "Русский", "English" }, resizeKeyboard: true);
                    message = "Выберите язык, на котором будем общаться/Select the language in which we will communicate";
                    break;
                case "Русский":
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>() { "USD=>BYN", "EUR=>BYN", "RUR=>BYN" }, resizeKeyboard: true);
                    message = "Выберите интересующую Вас валютную операцию:";
                    break;
                case "English":
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>() { "USD=>BYN", "EUR=>BYN", "RUR=>BYN" }, resizeKeyboard: true);
                    message = "Select the interesting foreign exchange operation:";
                    break;
                default:
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>() { "Вернуться назад" }, resizeKeyboard: true);
                    message = "Я не такой умный как Вы, перейдите к меню и выберите операцию";
                    break;
            }
        }

    }
}
