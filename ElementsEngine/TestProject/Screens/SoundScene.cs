using ElementsEngine.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;
using ElementsEngine.Core;
using ElementsEngine.GameObjects;
using ElementsEngine.ResourceManager;
using ElementsEngine.MathHelper;
using TestProject.Objects;
using ElementsEngine.Audio;

namespace TestProject.Screens
{
    public class SoundScene : SceneNode
    {
                    
        private PlayerShip _player;
        private SceneNode _background;
        public SoundBuffer buffer;
        private SoundCollection _sandSounds;
        private bool _spacePressed;
        
        public SoundScene()
        {
            var window = Game.Instance.Target;
            //_background = new SceneNode(ResourceManager.Instance.GetSpriteTexture("background"));
            //Add(_background);
            //_background.SetPosition(100, 200);

            _player = new PlayerShip(ResourceManager.Instance.GetSpriteTexture("planet"));
            Add(_player);
            /*
            for (var i = 0; i < 100; ++i)
            {
                var thing = new SceneNode(ResourceManager.Instance.GetSpriteTexture("basicHeart"));
                _background.Add(thing);
                thing.SetPosition(Game.Instance.GlobalRandom.Next(0, 800), Game.Instance.GlobalRandom.Next(0, 600));
            }
            */
            _spacePressed = false;
            _sandSounds = new SoundCollection();
            for (int i = 1; i < 6; ++i)
            {
                _sandSounds.AddSound(new ESound("Resources/Audio/" + i +".ogg"));
            }
        }

        public override void Update(float time)
        {
            //_background.Angle += 1f;
            var window = Game.Instance.Target;
            if(Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                _player.Accelerate(new Vector2f(0,-1));
            }
             if(Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                _player.Accelerate(new Vector2f(0,1));
            }
             if(Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
               _player.Accelerate(new Vector2f(-1,0));
            }
             if(Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                _player.Accelerate(new Vector2f(1, 0));
            }
             if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
             {
                 _spacePressed = true;
                 
                 var numSamples = 44100;
                 var samples = new short[numSamples];
                 var sound = new Sound();
                 for (var i = 0; i < numSamples; ++i)
                 {
                     var thing = Math.Sin(_player.X * (2.0f * Math.PI) * i / 22000)  * (_player.X / _player.Y);
                     samples[i] = (short)(_player.Y *thing);
                  //   samples[i] = (short)(2 * (i % (_player.X / 22000f)) / (_player.X / 22000f) - 1);
                 }

                 buffer = new SoundBuffer(samples, 2, 44100);
                 sound.SoundBuffer = buffer;
                 sound.Play();
                 
                // _sandSounds.Play();
             }
             else if(!Keyboard.IsKeyPressed(Keyboard.Key.Space))
             {
                 _spacePressed = false;
             }

            base.Update(time);
        }
    }
}
