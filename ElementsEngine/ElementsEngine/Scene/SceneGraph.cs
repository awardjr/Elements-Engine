using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsEngine.Scene
{
    public class SceneGraph
    {
        public List<SceneNode> Nodes { get; private set; }

        public SceneGraph()
        {
            Nodes = new List<SceneNode>();
        }

        public void Add(SceneNode node)
        {
            Nodes.Add(node);
        }

        public void Remove(SceneNode node)
        {
            Nodes.Remove(node);
        }

        public void Update(float time)
        {
            foreach (var node in Nodes)
            {
                node.Update(time);
            }
        }

        public void Draw()
        {
            foreach (var node in Nodes)
            {
                node.Draw(Transform.Identity);
            }
        }

        public void Clear()
        {
            foreach (var node in Nodes)
            {
                node.Destory();
            }

            Nodes.Clear();
        }
    }
}
