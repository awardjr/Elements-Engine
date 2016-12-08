using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsEngine.Elements.Grid
{
    public class TileAttributes
    {
        public int Weight { get; set; }
        public bool Highlighted { get; set; }
        public bool Impassable { get; set; }

        public TileAttributes(int tileWeight = 1, bool impassible = false)
        {
            Weight = tileWeight;
            Highlighted = false;
            Impassable = impassible;
        }
    }
}
