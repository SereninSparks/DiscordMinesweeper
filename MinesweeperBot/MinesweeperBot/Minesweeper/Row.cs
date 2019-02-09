using System;
using System.Text;
using MinesweeperBot.Minesweeper.Tiles;

namespace MinesweeperBot.Minesweeper
{
    class Row
    {
        public readonly Tile[] Tiles;

        public Row(int size)
        {
            Tiles = new Tile[size];
        }

        public void SetTile(int index, Tile tile)
        {
            Tiles[index] = tile;
        }

        public bool IsMineTile(int index)
        {
            try
            {
                return Tiles[index] is Mine;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (Tile tile in Tiles)
            {
                sb.Append(tile.GetDiscordEmoji());
            }

            return sb.ToString();
        }
    }
}
