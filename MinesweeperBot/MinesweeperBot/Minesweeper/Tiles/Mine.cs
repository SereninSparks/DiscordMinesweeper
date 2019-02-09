using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperBot.Minesweeper.Tiles
{
    class Mine : Tile
    {
        public override string ToString()
        {
            return string.Format("[{0}]", '.');
        }
    }
}
