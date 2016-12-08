using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsEngine.Elements.Grid
{
    public class Tile
    {
        public TileAttributes Attributes { get; set; }
        public Vector2i Position { get; set; }

        public Tile(int x, int y, int weight =1)
        {
            Attributes = new TileAttributes();
            Position = new Vector2i(x, y);
            Attributes.Weight = 1;
        }
    }
}
