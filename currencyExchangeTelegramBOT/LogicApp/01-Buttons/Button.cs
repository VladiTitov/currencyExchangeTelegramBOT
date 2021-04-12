using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace LogicApp._01_Buttons
{
    public class Button
    {
        public string Text { get; set; }

        public Button(string text) => Text = text;

        public void ReturnButtons(out string message, out ReplyKeyboardMarkup buttons)
        {
            switch (Text)
            {
                case "/start":
                    buttons = new ButtonsLogic("Лучший курс;Купить,Продать;Назад").ReturnMsgAndButtons();
                    message = "Выберите интерисующую Вас операцию:";
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
    }
}
