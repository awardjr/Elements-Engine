using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace ElementsEngine.Elements.Grid
{
    public class Grid
    {
        public Tile[,] TileGrid;
        public float ColWidth { get; private set; }
        public float ColHeight { get; private set; }
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public Grid(int cols, int rows, float colWidth = 0, float colHeight = 0)
        {
            TileGrid = new Tile[rows, cols];
            ColHeight = colHeight;
            ColWidth = colWidth;
            Rows = rows;
            Cols = cols;
            for (var i = 0; i < cols; ++i)
            {
                for (var j = 0; j < rows; ++j)
                {
                    TileGrid[i, j] = new Tile(i, j);
                }
            }
        }

        //I might try something later with a "Grid" where each tile doesn't have to be the same size but I'll think about that later. It might be something silly to think about anyway
        //this is gonna have to return an empty vector since SFML vectors aren't nullable
        public Vector2f GetRelativePosition(int x, int y)
        {
            if (!IsWithinGrid(x, y))
            {
                var newX = x;
                var newY = y;
                if (x > TileGrid.GetLength(0))
                {
                    newX = TileGrid.GetLength(0);
                }
                if (x < 0)
                {
                    newX = 0;
                }

                if (y > TileGrid.GetLength(1))
                {
                    newY = TileGrid.GetLength(1);
                }

                if (y < 0)
                {
                    newY = 0;
                }
                return new Vector2f(newY, newY);
            }

            return new Vector2f(x * ColWidth, y * ColHeight);
        }

        public bool IsWithinGrid(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Cols && y < Rows)
            {
                return true;
            }
            return false;
        }

        public void HighlightValidMoves(Vector2i position, int spaces)
        {
            if (IsWithinGrid(position.X, position.Y))
            {
                spaces -= TileGrid[position.X, position.Y].Attributes.Weight;
                if (TileGrid[position.X, position.Y].Attributes.Impassable)
                {
                    spaces = 0;
                }

                if (spaces >= 0)
                {
                    TileGrid[position.X, position.Y].Attributes.Highlighted = true;

                    HighlightValidMoves(position + new Vector2i(-1, 0), spaces);
                    HighlightValidMoves(position + new Vector2i(1, 0), spaces);
                    HighlightValidMoves(position + new Vector2i(0, -1), spaces);
                    HighlightValidMoves(position + new Vector2i(0, 1), spaces);
                }
            }
        }
    }
}
