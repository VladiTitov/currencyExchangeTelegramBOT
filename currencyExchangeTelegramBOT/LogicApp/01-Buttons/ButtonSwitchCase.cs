using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace LogicApp._01_Buttons
{
    class ButtonSwitchCase
    {
        public void ReturnAnswer(string msg, out string message, out ReplyKeyboardMarkup buttons)
        {
            switch (msg)
            {
                case "/start":
                    buttons = new ButtonsLogic("Лучший курс;Купить,Продать;Назад").ReturnMsgAndButtons();
                    message = "Выберите интерисующую Вас операцию:";
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
                    KeyboardButton key = new KeyboardButton();
                    key.Text = "test";
                    buttons = new ReplyKeyboardMarkup(new List<KeyboardButton>()
                        {
                            "Вернуться назад"
                        },
                        resizeKeyboard: true);
                    message = "Я не такой умный как Вы, перейдите к меню и выберите операцию";
                    break;
            }
        }

        private string TranslateText(string inText) => inText;

    }
}
