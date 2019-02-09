using System;

namespace MinesweeperBot.Minesweeper
{
    public struct MinesweeperParams
    {
        public int Width { get; }
        public int Height { get; }
        public int Mines { get; }

        public MinesweeperParams(int[] args)
        {
            Width = args[0];

            if (args.Length > 2)
            {
                Height = args[1];
                Mines = args[2];
            }
            else
            {
                Height = args[0];
                Mines = args[1];
            }

            if ((Width * Height) < Mines)
            {
                throw new ArgumentException("Too many mines!");
            }
        }

        public override string ToString()
        {
            return string.Format("Width = {0}, Height = {1}, Mines = {2}", Width, Height, Mines);
        }
    }
}