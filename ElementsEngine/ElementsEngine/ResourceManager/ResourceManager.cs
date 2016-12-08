using ElementsEngine.AssetInfo;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ElementsEngine.ResourceManager
{
    public class ResourceManager
    {
        private static ResourceManager _instance;

        private XElement _settings;
        private readonly List<Texture> _textures; 
        private readonly Dictionary<string, SpriteInfo> _spriteData;
        private string _textureResourcePath;

        public static ResourceManager Instance
        {
            get { return _instance ?? (_instance = new ResourceManager()); }
        }

        
        private ResourceManager()
        {
            _spriteData = new Dictionary<string, SpriteInfo>();
            _textures = new List<Texture>();
        }

        /// <summary>
        /// Loads a resource definitions
        /// </summary>
        /// <param name="path">Path to resource settings. Might be redefined later</param>
        public void LoadResources(string path)
        {
           _settings = XElement.Load(path);
           foreach (var element in _settings.Elements())
           {
               if (element != null && element.Name == "TextureData" )
               {
                   _textureResourcePath = element.Attribute("resourcePath").Value;
                   LoadTextures(XElement.Load("Resources/ResourceDefinitions/" + element.Attribute("path").Value));
               }
               else
               {
                   throw new Exception("Texture Data source not defined!");
               }
           }
        }

        private void LoadTextures(XElement textureAtlasInfo)
        {
            var atlasTexture = new Texture(textureAtlasInfo.Attribute("imagePath").Value);
            _textures.Add(atlasTexture);
            foreach (var spriteData in textureAtlasInfo.Elements())
            {
                _spriteData.Add(spriteData.Attribute("n").Value, new SpriteInfo(spriteData, atlasTexture));
            }
        }

        /// <summary>
        /// Gets the sprite info for specified sprite
        /// </summary>
        /// <param name="name">Sprite info to retrieve</param>
        /// <returns></returns>
        public SpriteInfo GetSpriteTexture(string name)
        {
            return _spriteData[name];
        }
    }
}
