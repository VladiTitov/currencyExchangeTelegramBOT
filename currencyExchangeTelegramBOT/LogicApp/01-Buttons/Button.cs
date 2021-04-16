using System.Collections.Generic;

namespace LogicApp._01_Buttons
{
    public class Button
    {
        private Dictionary<int, string> buttonsDictionary = new Dictionary<int, string>()
        {
            [0] = "В начало",
            [1] = "Назад",
            [2] = "Лучший курс",
            [3] = "Поиск по банкам",
            [4] = "Поиск по локации",
            [5] = "Список адресов",
            [6] = "Список банков",
            [7] = "Позвонить",
            [8] = "Купить",
            [9] = "Продать",
            [10] = "USD",
            [11] = "EUR",
            [12] = "RUB"
        };


        public int Id { get; }

        public Button(string text)
        {
            Id = ReturnIdButton(text);
        }


        private int ReturnIdButton(string text)
        {
            foreach (var dict in buttonsDictionary)
            {
                if (dict.Value == text) return dict.Key;
            }
            return 0;
        }

        private string DropBtnName(string text)
        {


            return "";
        }
    }

    public struct ButtonMenu
    {
        private Button firstButtonLine;
        private List<Button> secondButtonLine;
        private Button thirdButtonLine;

        public ButtonMenu(Button _first, List<Button> _second, Button _third)
        {
            firstButtonLine = _first;
            secondButtonLine = _second;
            thirdButtonLine = _third;
        }
    }
}
