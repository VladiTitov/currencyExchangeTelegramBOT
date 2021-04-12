using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace Core._02_Buttons
{
    class Buttons
    {
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

        public (string Message, ReplyKeyboardMarkup Buttons) ReturnMsgAndButtons(string msg, string buttonsList) =>
            (msg, new ReplyKeyboardMarkup(new List<KeyboardButton>() { buttonsList }, resizeKeyboard: true));
    }
}
