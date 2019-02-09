using System;
using System.Collections.Generic;
using MinesweeperBot.Discord;

namespace MinesweeperBot.Minesweeper.Tiles
{
    class Tile : IDiscordEmoji
    {
        public string Text { get; set; }

        private Dictionary<string, string> emojis = new Dictionary<string, string>()
        {
            { "0", ":zero:" },
            { "1", ":one:" },
            { "2", ":two:" },
            { "3", ":three:" },
            { "4", ":four:" },
            { "5", ":five:" },
            { "6", ":six:" },
            { "7", ":seven:" },
            { "8", ":eight:" },
            { "9", ":nine:" },
        };

        public override string ToString()
        {
            return string.Format("[{0}]", Text);
        }

        public string GetDiscordEmoji()
        {
            if (this is Mine)
            {
                return "||:bomb:||";
            }

            return $"||{emojis[Text]}||";
        }
    }
}
