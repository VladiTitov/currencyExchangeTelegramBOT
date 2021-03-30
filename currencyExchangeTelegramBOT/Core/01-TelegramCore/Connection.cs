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

        public async void BotClient_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;

            if (text == null) return;

            ReturnAnswer(text, out text, out _keyboard);

            await botClient.SendTextMessageAsync(chatId: e.Message.Chat, text: text, replyMarkup: _keyboard).ConfigureAwait(false);
        }

        public void ReturnAnswer(string msg, out string message, out ReplyKeyboardMarkup buttons)
        {
            switch (msg)
            {
                case "/start":
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                    {
                        "Русский", 
                        "English"
                    }, 
                        resizeKeyboard: true);
                    message = "Выберите язык, на котором будем общаться/Select the language in which we will communicate";
                    break;
                case "Русский":

                    ReturnMsgAndButtons("Выберите интересующую Вас валюту: ", "USD - Доллар, EUR-Евро, RUB-Российский рубль");
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                    {
                        "USD-Доллар",
                        "EUR-Евро", 
                        "RUB-Российский рубль"
                    }, 
                        resizeKeyboard: true);
                    message = "Выберите интересующую Вас валюту:";
                    break;
                case "English":
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                    {
                        "USD-Dollar",
                        "EUR-Euro",
                        "RUB-Russian ruble"
                    }, 
                        resizeKeyboard: true);
                    message = "Select the currency you are interested in:";
                    break;
                default:
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                    {
                        "Вернуться назад"
                    }, 
                        resizeKeyboard: true);
                    message = "Я не такой умный как Вы, перейдите к меню и выберите операцию";
                    break;
            }
        }

        public (string Message, ReplyKeyboardMarkup Buttons) ReturnMsgAndButtons(string msg, string buttonsList)
        {
            return (msg, new ReplyKeyboardMarkup(new List<KeyboardButton>() {buttonsList}, resizeKeyboard: true));
        }


    }
}
