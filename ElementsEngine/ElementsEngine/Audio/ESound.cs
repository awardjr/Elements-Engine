using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;

namespace ElementsEngine.Audio
{
    //Todo: Rename this ugh
    
    public class ESound
    {
        private SoundBuffer _soundBuffer;
        private Sound _sound;

        public ESound(string filename)
        {
            _soundBuffer = new SoundBuffer(filename);
            _sound = new Sound();
            _sound.SoundBuffer = _soundBuffer;
        }

        public void Play()
        {
            _sound.Play();
        }
    }
}
