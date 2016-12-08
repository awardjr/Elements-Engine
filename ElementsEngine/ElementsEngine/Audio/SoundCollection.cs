using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;
using ElementsEngine.Core;
using ElementsEngine.Utilities;

namespace ElementsEngine.Audio
{
    public class SoundCollection
    {

        //Collection of sounds
        //This and Esound will be expanded to support some cool features. Removed for now since they were broken but leaving the base here.
        private List<ESound> _sounds;
        private int _soundIndex;

        public SoundCollection()
        {
            _sounds = new List<ESound>();
            _soundIndex = 0;
        }

        public void AddSound(ESound sound)
        {
            _sounds.Add(sound);
            _sounds.Shuffle();
        }

        public void Play()
        {
            _sounds[_soundIndex].Play();

            _soundIndex++;
            if(_soundIndex >= _sounds.Count())
            {
                _soundIndex = 0;
                _sounds.Shuffle();
            }
        }
    } 
}
