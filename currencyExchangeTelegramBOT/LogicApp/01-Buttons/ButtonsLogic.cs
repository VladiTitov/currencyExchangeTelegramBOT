using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace LogicApp
{
    public class ButtonsLogic
    {
        public string UrlPart { get; set; }

        public string ButtonList { get; set; }

        public ButtonsLogic(string urlPart, string buttonsList)
        {
            UrlPart = urlPart;
            ButtonList = buttonsList;
        }

        public ButtonsLogic(string buttonsList)
        {
            ButtonList = buttonsList;
            //
            //new BanksData();
        }



        public ReplyKeyboardMarkup ReturnMsgAndButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = ReturnButtons(ButtonList),
                ResizeKeyboard = true,
            };
        }

        private KeyboardButton[][] ReturnButtons(string buttonsList)
        {
            string[] data = buttonsList.Split(';');
            KeyboardButton[][] buttons = new KeyboardButton[data.Length][];

            for (int i = 0; i < data.Length; i++)
            {
                List<KeyboardButton> btns = new List<KeyboardButton>();
                foreach (string btn in data[i].Split(','))
                {
                    btns.Add(new KeyboardButton(btn));
                }

                buttons[i] = btns.ToArray();
            }

            return buttons;
        }

        

        
    }
}
