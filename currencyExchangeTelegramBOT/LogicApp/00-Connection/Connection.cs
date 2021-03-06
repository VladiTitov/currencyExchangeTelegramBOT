﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BusinessLogic
{
    public class Connection
    {
        private readonly string _token;

        private static ITelegramBotClient _botClient;
        private static IReplyMarkup _markup;

        public Connection(string token) => _token = token;

        public void Start()
        {
            _botClient = new TelegramBotClient(_token) { Timeout = TimeSpan.FromSeconds(10) };
            User me = _botClient.GetMeAsync().Result;

            Console.WriteLine($"{me.Id} and {me.FirstName} started");

            _botClient.OnMessage += BotClient_OnMessage;
            _botClient.StartReceiving();
        }



        public async void BotClient_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;

            if (text == null) return;

            ArchitectureMenu.MenuButtonEvent(new Button(text), out text, out _markup);

            var betaControl3 = new InlineKeyboardButton() { Text = "test1", CallbackData = "1" };
            _markup = new InlineKeyboardMarkup(new[] { betaControl3 });

            await SendMessage(e.Message.Chat, text, _markup);
        }

        private Task SendMessage(Chat chat, string text, IReplyMarkup replyMarkup) => _botClient.SendTextMessageAsync(chatId: chat, text: text,
            ParseMode.Default, true, false, 0, replyMarkup: replyMarkup, CancellationToken.None);
    }
}
