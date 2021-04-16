using LogicApp._01_Buttons;
using Telegram.Bot.Types.ReplyMarkups;

namespace LogicApp._02_MenuBot
{
    public static class ArchitectureMenu
    {
        public static int State { get; set; } = 0;

        public static void MenuButtonEvent(Button btn, out string message, out ReplyKeyboardMarkup buttons)
        {
            MenuStep(btn.Id);
            buttons = MenuState(State);
            message = "Выберите нужную операцию:";
        }

        private static void MenuStep(int id)
        {
            switch (id)
            {
                case 0:
                    State = 1;
                    break;
                case 1:
                    State--;
                    break;
                default:
                    State++;
                    break;
            }
        }

        private static ReplyKeyboardMarkup MenuState(int state)
        {
            switch (state)
            {
                case 1:
                    return new ButtonsLogic("USD,EUR,RUB").ReturnMsgAndButtons();
                case 2:
                    return new ButtonsLogic("Купить,Продать;Назад").ReturnMsgAndButtons();
                case 3:
                    return new ButtonsLogic("Лучший курс;Поиск по банкам,Поиск по локации;Назад").ReturnMsgAndButtons();
                case 4:
                    return new ButtonsLogic("Список банков-курс;Назад").ReturnMsgAndButtons();
                case 5:
                    return new ButtonsLogic("Лучший курс-курс;Список адресов,Поиск ближайшего отделения;Назад").ReturnMsgAndButtons();
                case 6:
                    return new ButtonsLogic("Адрес-курс;Назад").ReturnMsgAndButtons();
                case 7:
                    return new ButtonsLogic("Позвонить,Адрес;Назад").ReturnMsgAndButtons();
                default:
                    return new ButtonsLogic("В начало").ReturnMsgAndButtons();
            }
        }
    }
}
