using ElementsEngine.GameObjects;
using ElementsEngine.Scene;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsEngine.Particles
{
    public class ParticleObject : SceneNode
    {
        public bool Fade { get; private set; }
        public float DecayTime { get; private set; }
        public Vector2f Acceleration { get; private set; }
        public float RotationRate { get; private set; }


        public ParticleObject() : base()
        {

        }





    }
}
