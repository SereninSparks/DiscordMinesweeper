using System;

namespace MinesweeperBot.Minesweeper
{
    public struct MinesweeperParams
    {
        public int Width { get; }
        public int Height { get; }
        public int Mines { get; }

        public MinesweeperParams(int width, int height, int mines)
        {
            Width = width;
            Height = height;
            Mines = mines;
        }

        public override string ToString()
        {
            return string.Format("Width = {0}, Height = {1}, Mines = {2}", Width, Height, Mines);
        }
    }
}