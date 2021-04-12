using System.Collections.Generic;
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
                            "Продать",
                            "Купить"
                        },
                        resizeKeyboard: true);
                    message = "Выберите необходимую операцию:";
                    break;

                #region Мультиязычность
                #region Мультиязычность

                //buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                //    {
                //        "Русский",
                //        "English"
                //    },
                //    resizeKeyboard: true);
                //message = "Выберите язык, на котором будем общаться/Select the language in which we will communicate";
                //break;

                #endregion

                case "Русский":

                    ReturnMsgAndButtons("Выберите интересующую Вас валюту: ",
                        "USD - Доллар, EUR-Евро, RUB-Российский рубль");
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                        {
                            "USD-Доллар $",
                            "EUR-Евро €",
                            "RUB-Российский рубль ₽"
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

                #endregion

                #region Купить/Продать

                case "Продать":
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                        {
                            "USD $",
                            "EUR €",
                            "RUB ₽"
                        },
                        resizeKeyboard: true);
                    message = "Выберите интересующую Вас валюту:";
                    break;

                case "Купить":
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                        {
                            "USD $",
                            "EUR €",
                            "RUB ₽"
                        },
                        resizeKeyboard: true);
                    message = "Выберите интересующую Вас валюту:";
                    break;

                #endregion

                #region Доллар

                case "USD $":
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                        {
                            $"Лучший курс покупки {"2"}",
                            "Перейти к банкам",
                            "Показать все курсы"
                        },
                        resizeKeyboard: true);
                    message = "Курсы в Минске на данный момент:";
                    break;

                #endregion

                #region Евро

                case "EUR €":
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                        {
                            $"Лучший курс покупки {"2"}",
                            "Перейти к банкам",
                            "Показать все курсы"
                        },
                        resizeKeyboard: true);
                    message = "Курсы в Минске на данный момент:";
                    break;

                #endregion

                #region Рубль

                case "RUB ₽":
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                        {
                            $"Лучший курс покупки {"2"}",
                            "Перейти к банкам",
                            "Показать все курсы"
                        },
                        resizeKeyboard: true);
                    message = "Курсы в Минске на данный момент:";
                    break;

                #endregion

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

        private (string Message, ReplyKeyboardMarkup Buttons) ReturnMsgAndButtons(string msg, string buttonsList) =>
            (msg, new ReplyKeyboardMarkup(new List<KeyboardButton>() {buttonsList}, resizeKeyboard: true));

        private string TranslateText(string inText) => inText;

    }
}
