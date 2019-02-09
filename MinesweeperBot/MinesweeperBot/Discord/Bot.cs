using System;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using Discord;
using Discord.WebSocket;
using MinesweeperBot.Minesweeper;

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
            var pattern = @"^!minesweeper (\d+) (\d+)\s?(\d+)?";

            if (Regex.IsMatch(message.Content, pattern))
            {
                var match = Regex.Match(message.Content, pattern, RegexOptions.IgnoreCase);
                var groups = match.Groups;

                var width = 10;
                var height = 10;
                var mines = 10;

                int.TryParse(groups[1].Value, out width);

                if (string.IsNullOrEmpty(groups[3].Value))
                {
                    height = width;
                    int.TryParse(groups[2].Value, out mines);
                }
                else
                {
                    int.TryParse(groups[2].Value, out height);
                    int.TryParse(groups[3].Value, out mines);
                }

                if (width > 15)
                {
                    await message.Channel.SendMessageAsync(string.Format("Whoa there partner, {0} is too wide! Please make it 15 wide or less", width));
                    return;
                }
                else if (height > 15)
                {
                    await message.Channel.SendMessageAsync(string.Format("Whoa there partner, {0} is too high! Please make it 15 high or less", width));
                    return;
                }
                else if ((width * height) > 110)
                {
                    await message.Channel.SendMessageAsync("Whoa there partner, I can't make the field that big! Please make the field at most 110 squares big");
                    return;
                }
                else if ((width * height) < mines)
                {
                    await message.Channel.SendMessageAsync(string.Format("Look, I understand you like a challenge, but how am I supposed to fit {0} mines in {1} squares? :thinking:", mines, width * height));
                    return;
                }

                var parameters = new MinesweeperParams(width, height, mines);

                Console.WriteLine("Creating a field of {0} x {1} with {2} mines", parameters.Width, parameters.Height, parameters.Mines);

                var field = new Minefield(parameters);

                string fieldString = field.ToString();

                await message.Channel.SendMessageAsync(field.ToString());
            }
        }
    }
}
