using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperBot.Minesweeper.Tiles
{
    class Tile
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]", Text);
        }
    }
}
