using Telegram.Bot.Types.ReplyMarkups;

namespace BusinessLogic
{
    public static class ArchitectureMenu
    {
        private static int State { get; set; } = 0;

        public static void MenuButtonEvent(Button btn, out string message, out IReplyMarkup buttons)
        {
            MenuStep(btn.Text);
            buttons = new ButtonsLogic(MenuState(State)).ReturnMsgAndButtons();
            message = "Выберите нужную операцию:";
        }

        private static void MenuStep(string text)
        {
            switch (text)
            {
                case "/start":
                    State = 1;
                    break;
                case "Купить":
                    State++;
                    //параметр покупки
                    break;
                case "Продать":
                    State++;
                    //параметр продажи
                    break;
                case "USD":
                    State++;
                    //парамерт валюты
                    break;
                case "EUR":
                    State++;
                    //парамерт валюты
                    break;
                case "RUB":
                    State++;
                    //парамерт валюты
                    break;
                case "Назад":
                    State--;
                    break;
            }
        }

        private static string MenuState(int state)
        {
            return state switch
            {
                1 => "USD,EUR,RUB",
                2 => "Купить,Продать;Назад",
                3 => "Лучший курс;Поиск по банкам,Поиск по локации;Назад",
                4 => "Список адресов,Поиск ближайшего отделения;Назад",
                5 => "Позвонить,Адрес;Назад",
                _ => "В начало"
            };
        }
    }
}
