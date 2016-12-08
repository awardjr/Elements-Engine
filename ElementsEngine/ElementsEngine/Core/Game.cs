using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElementsEngine.Scene;
using ElementsEngine.Time;
using SFML.Window;
using SFML.Graphics;

namespace ElementsEngine.Core
{
    public class Game
    {
        public SceneGraph SceneGraph {get; private set;}
        public bool isRunning;
        public Gametime GameTime { get; private set; }
        public RenderWindow Target { get; private set; }

        public Random GlobalRandom { get; private set; }        
        private static Game _instance;

        public static Game Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Game();
                }   
                return _instance;
            }
        }

        public Game()
        {
            GameTime = new Gametime();
            SceneGraph = new SceneGraph();
            //We might want to save a seed later on  but for now...
            GlobalRandom = new Random();
        }


        public void Initialize(RenderWindow target)
        {
            Target = target;
        }

        public void Run()
        {
            GameTime.Update();
            SceneGraph.Update(GameTime.DeltaTime);
            SceneGraph.Draw();
        }
    }
}
