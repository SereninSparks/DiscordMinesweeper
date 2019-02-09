using System;
using System.Collections.Generic;
using System.Text;
using MinesweeperBot.Minesweeper.Tiles;

namespace MinesweeperBot.Minesweeper
{
    class Field
    {
        public Row[] Rows { get; private set; }

        public Field(MinesweeperParams parameters)
        {
            Initialize(parameters.Width, parameters.Height, parameters.Mines);
        }

        private void Initialize(int width, int height, int mines)
        {
            Rows = new Row[height];

            for (int i = 0; i < height; i++)
            {
                Rows[i] = new Row(width);
            }

            SetMines(width, height, mines);
            SetTiles();
        }

        private void SetMines(int width, int height, int mines)
        {
            int minesSet = 0;
            var r = new Random();

            while (minesSet < mines)
            {
                int x = r.Next(0, width);
                int y = r.Next(0, width);

                var row = Rows[y];

                if (!row.IsMineTile(x))
                {
                    row.SetTile(x, new Mine());
                    minesSet++;
                }
            }
        }

        private void SetTiles()
        {
            for (int y = 0; y < Rows.Length; y++)
            {
                var row = Rows[y];
                var prevRowIndex = y - 1;
                var nextRowIndex = y + 1;

                for (int x = 0; x < row.Tiles.Length; x++)
                {
                    if (row.IsMineTile(x))
                    {
                        continue;
                    }

                    int surroundingBombs = GetSurroundingBombs(row, prevRowIndex, nextRowIndex, x);

                    row.SetTile(x, new Tile
                    {
                        Text = surroundingBombs.ToString(),
                    });
                }
            }
        }

        private int GetSurroundingBombs(Row row, int prevRowIndex, int nextRowIndex, int tileIndex)
        {
            int bombCount = GetSurroundingBombsInRow(row, tileIndex);
            Row prevRow = null;
            Row nextRow = null;

            if (prevRowIndex >= 0)
            {
                prevRow = Rows[prevRowIndex];
                bombCount += GetSurroundingBombsInRow(prevRow, tileIndex);
            }

            if (nextRowIndex < Rows.Length)
            {
                nextRow = Rows[nextRowIndex];
                bombCount += GetSurroundingBombsInRow(nextRow, tileIndex);
            }

            return bombCount;
        }

        private int GetSurroundingBombsInRow(Row row, int tileIndex)
        {
            int bombCount = 0;

            if (row.IsMineTile(tileIndex - 1))
            {
                bombCount++;
            }

            if (row.IsMineTile(tileIndex))
            {
                bombCount++;
            }

            if (row.IsMineTile(tileIndex + 1))
            {
                bombCount++;
            }

            return bombCount;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            foreach (Row row in Rows)
            {
                sb.Append(row.ToString() + "\n");
            }

            return sb.ToString();
        }
    }
}
