using ElementsEngine.Core;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsEngine.Scene
{
    public class SceneNode : Transformable
    {

        public List<SceneNode> Nodes;
        public RenderTarget Target;
        public SceneNode Parent { get; private set; }
        public IntRect BoundingBox { get; private set; }


        private Sprite _sprite;
        private float _x;
        private float _y;
        private float _angle;

        public float X
        {
            get { return _x; }
            set
            {
                _x = value;
                UpdatePosition();
            }
        }
        public float Y
        {
            get { return _y; }
            set
            {
                _y = value;
                UpdatePosition();
            }
        }

        public float Angle
        {
            get { return _angle; }
            set
            {
                _angle = value;
                UpdatePosition();
            }
        }

        

        public SceneNode()
        {
            _sprite = new Sprite();
            Initialize();
        }
        public SceneNode(Texture texture)
        {
            _sprite = new Sprite(texture);
            Initialize();
        }
        public SceneNode(Texture texture, IntRect rectangle) 
        {
            _sprite = new Sprite(texture, rectangle);
            Initialize();
        }

        public SceneNode(AssetInfo.SpriteInfo spriteInfo) 
        {
            _sprite = new Sprite(spriteInfo.AtlasTexture, spriteInfo.Rectangle);
            Initialize();
        }


        public void Initialize()
        {
            Nodes = new List<SceneNode>();
            Parent = null;
            BoundingBox = _sprite.TextureRect;
        }

        public void Add(SceneNode node)
        {
            Nodes.Add(node);
            node.SetParent(this);
        }

        public void Remove(SceneNode node)
        {
            Nodes.Remove(node);
        }

        public void SetRenderTarget(RenderTarget target)
        {
            Target = target;
        }

        public virtual void Update(float time)
        {
            foreach (var node in Nodes)
            {
                node.Update(time);
            }
        }

        public void SetPosition(float x, float y)
        {
            _x = x;
            _y = y;
            UpdatePosition();
          
        }

        public void SetRotation(float r)
        {
            _angle = r;
            UpdatePosition();
        }


        public void UpdatePosition()
        {
            Rotation = _angle;
            Position = new Vector2f(_x, _y);
            foreach (var node in Nodes)
            {
                node.UpdatePosition();
            }
        }


        public void SetParent(SceneNode parent)
        {
            Parent = parent;
        }

        public virtual void Destory()
        {
            foreach (var node in Nodes)
            {
                node.Destory();
            }
            Nodes.Clear();
        }

        public virtual void Draw(Transform pTransform, RenderTarget target = null)
        {
            RenderTarget renderTarget;
            if (target != null)
            {
                renderTarget = target;
            }
            else
            {
                renderTarget = Game.Instance.Target;
            }

            pTransform.Combine(Transform);
            renderTarget.Draw(_sprite, new RenderStates(pTransform));
            foreach (var node in Nodes)
            {
                node.Draw(pTransform, target);
            }
        }
    }
}
