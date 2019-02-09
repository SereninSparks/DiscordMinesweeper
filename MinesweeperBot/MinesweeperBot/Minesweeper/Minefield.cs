using System;
using System.Collections.Generic;
using System.Text;
using MinesweeperBot.Minesweeper.Tiles;

namespace MinesweeperBot.Minesweeper
{
    class Minefield
    {
        private MinesweeperParams Parameters;
        public readonly Field Field;

        public Minefield(MinesweeperParams parameters)
        {
            Parameters = parameters;
            Field = new Field(parameters);
        }

        public override string ToString() => Field.ToString();
    }
}
