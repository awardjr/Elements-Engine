using System;
using ElementsEngine.ResourceManager;
using SFML.Window;
using SFML.Graphics;
using System.Collections.Generic;
using ElementsEngine.Core;
using TestProject.Screens;

namespace TestProject
{
    public class TextProject
    {
        public TimeSpan GameTime;
        private static RenderWindow _window;
        private static List<float> _frameTime;
        //private static RenderWindow _window2;

        public static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            var window = (RenderWindow)sender;
            window.Close();

        }

        public static void Main()
        {
            //Most of this is gonna be moved into the main engine, just doing this for quick tests.
            // Create the main window
            _window = new RenderWindow(new VideoMode(1280, 720), "SFML window", Styles.Close);
            //  _window2 = new RenderWindow(new VideoMode(1280, 720), "SFML window", Styles.Close);
            _frameTime = new List<float>();
            _window.Closed += new EventHandler(OnClose);
            _window.KeyPressed += OnKeyPressed;
            _window.SetFramerateLimit(60);
            Game.Instance.Initialize(_window);
            // Game.Instance.Initialize(_window2);
            ResourceManager.Instance.LoadResources("Resources/ResourceDefinitions/resources.xml");
            // Start the game loop
            Font font = new Font("arial.ttf");
            Text text = new Text("", font);

            Game.Instance.SceneGraph.Add(new SoundScene());

            while (_window.IsOpen())
            {

                _window.DispatchEvents();
                _window.Clear(new Color(0, 0, 0));

                Game.Instance.Run();
                _frameTime.Add(1 / Game.Instance.GameTime.DeltaTime);

                if (_frameTime.Count == 60)
                {
                    float sum = 0;
                    foreach (float fTime in _frameTime)
                    {
                        sum += fTime;
                    }
                    _frameTime.Clear();
                    text.DisplayedString = (sum / 60f).ToString();
                }


                _window.Draw(text);
                _window.Display();

                /*
                _window2.DispatchEvents();
                _window2.Clear(new Color(0, 0, 0));

                Game.Instance.Run();
                text.DisplayedString = (1 / Game.Instance.GameTime.DeltaTime).ToString();
                _window2.Draw(text);
                _window2.Display();
                */
            }


            Environment.Exit(1);
        }

        private static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                _window.Close();
            }
        }
    }
}

