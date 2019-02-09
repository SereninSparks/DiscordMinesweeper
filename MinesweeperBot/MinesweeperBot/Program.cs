using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MinesweeperBot.Minesweeper;
using MinesweeperBot.Discord;
using System.Threading.Tasks;

namespace MinesweeperBot
{
    class Program
    {
        private IConfigurationRoot Config;

        public Program()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Config = builder.Build();
        }

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run().GetAwaiter().GetResult();
        }

        public async Task Run()
        {
            var bot = new Bot();
            var token = Config["Discord:Token"];

            await bot.StartAsync(token);
        }
    }
}
