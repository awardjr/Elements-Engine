using ElementsEngine.AssetInfo;
using ElementsEngine.GameObjects;
using ElementsEngine.MathHelper;
using ElementsEngine.ResourceManager;
using ElementsEngine.Scene;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Objects
{
    public struct ShipTypes
    {
        public static string Basic = "basic";
    }

    public class PlayerShip : SceneNode
    {
        public string ShipType { get; private set; }

        public Vector2f Velocity { get; set; }
        private Vector2f _acceleration;
        public float Acceleration { get; private set; }
        public float Deceleration { get; private set; }

        public PlayerShip(SpriteInfo spriteInfo) : base(spriteInfo)
        {
            ShipType = ShipTypes.Basic;
            _acceleration = new Vector2f();
            Velocity = new Vector2f();
            Deceleration = 0.2f;
        }


        public void Accelerate(Vector2f acceleration)
        {
            _acceleration += acceleration;
        }

        public override void Update(float time)
        {
            Velocity += _acceleration;
            X += Velocity.X;
            Y += Velocity.Y;
            _acceleration = new Vector2f();

            if (Math.Abs(Velocity.X) > 0)
            {
                Velocity = new Vector2f(Velocity.X - (Velocity.X / Math.Abs(Velocity.X) * Deceleration), Velocity.Y);
            }
            if (Math.Abs(Velocity.Y) > 0)
            {
                Velocity = new Vector2f(Velocity.X, Velocity.Y - (Velocity.Y / Math.Abs(Velocity.Y) * Deceleration));
            }

            if (Math.Abs(Velocity.X) <= 0.2)
            {
                Velocity = new Vector2f(0, Velocity.Y);
            }
            
            if (Math.Abs(Velocity.Y) <= 0.2)
            {
                Velocity = new Vector2f(Velocity.X, 0);
            }

            Velocity = new Vector2f(MathHelper.Clamp(Velocity.X, -10, 10), MathHelper.Clamp(Velocity.Y, -10, 10));
            base.Update(time);
        }

    }
}
