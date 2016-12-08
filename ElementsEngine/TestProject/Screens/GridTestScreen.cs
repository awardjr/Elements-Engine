using ElementsEngine.Elements.Grid;
using ElementsEngine.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;

namespace TestProject.Screens
{
    public class GridTestScreen : SceneNode
    {

        private Grid _grid;

        public GridTestScreen()
        {
            _grid = new Grid(10, 10);
             _grid.TileGrid[4,6].Attributes.Weight = 2;
            _grid.HighlightValidMoves(new Vector2i(4, 5), 4);
           for(int i = 0; i < _grid.Rows; ++i)
           {
               for(int j = 0; j < _grid.Cols; ++j)
               {
                   if (_grid.TileGrid[i, j].Attributes.Highlighted)
                   {
                        System.Console.Write("H ");
                    }
                    else
                    {
                       System.Console.Write("* ");
                    }
               }

              
               System.Console.WriteLine("");

           }
        }
    }
}
