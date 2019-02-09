using System;
using System.Configuration;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace MinesweeperBot.Discord
{
    class Bot
    {
        public async Task StartAsync(string token)
        {
            var client = new DiscordSocketClient();
            client.Log += Log;

            client.MessageReceived += OnMessage;

            await client.LoginAsync(TokenType.Bot, token);

            await client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task OnMessage(SocketMessage message)
        {
            string content = message.Content;

            await message.Channel.SendMessageAsync(content);
        }
    }
}
