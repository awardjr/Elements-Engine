using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SFML.Graphics;

namespace ElementsEngine.AssetInfo
{
    public class SpriteInfo
    {

        public string Name { get; private set; }
        public IntRect Rectangle { get; private set; }
        public Texture AtlasTexture { get; private set; }

        public SpriteInfo(XElement xml, Texture atlasTexture)
        {
            AtlasTexture = atlasTexture;
            if (xml.Name != "sprite")
            {
                throw new Exception("Not a valid sprite definition!");
            }
            
            Name = xml.Attribute("n").Value;
            Rectangle = new IntRect(
                                        int.Parse(xml.Attribute("x").Value), 
                                        int.Parse(xml.Attribute("y").Value),
                                        int.Parse(xml.Attribute("w").Value), 
                                        int.Parse(xml.Attribute("h").Value));

        }
    }
}
