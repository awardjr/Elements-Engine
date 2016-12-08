using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementsEngine.Scene;
using ElementsEngine.Time;
using SFML.Window;
using SFML.Graphics;

namespace ElementsEngine.Collision
{
    public class CollisonManager
    {
        private static CollisonManager _instance;
       
         public static CollisonManager Instance
        {
            get { return _instance ?? (_instance = new CollisonManager()); }
        }

        private CollisonManager()
        {

        }


        public bool isColliding(IntRect a, IntRect b)
        {
            return a.Intersects(b);
        }
    }
}
