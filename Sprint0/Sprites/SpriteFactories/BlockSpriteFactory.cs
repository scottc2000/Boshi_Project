using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Net.Http.Json;
using System.Reflection;
using System.ComponentModel.Design.Serialization;
using Sprint0.Sprites.BlockSprites;

namespace Sprint0.Sprites
{
    public class BlockSpriteFactory : ISpriteFactory
    {
        private Texture2D blockTextures;
        private Dictionary<string, Rectangle> nonanimated_sprites;
        private Dictionary<string, Rectangle[]> animated_sprites;
        private static BlockSpriteFactory spriteFactory = new BlockSpriteFactory();

        private string fileName { get; set; }
        private string jsonString { get; set; }

        public static BlockSpriteFactory Instance
        {
            get => spriteFactory;
        }

        public BlockSpriteFactory()
        {
            nonanimated_sprites = new Dictionary<string, Rectangle>();
            animated_sprites = new Dictionary<string, Rectangle[]>();
        }

        public void LoadTextures(ContentManager content)
        {
            blockTextures = content.Load<Texture2D>("SpriteImages/blocks");
        }

        public void LoadSpriteLocations(ContentManager content)
        {
            // Deserialize the JSON data into an object
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "JSON/blockdata.json");
            jsonString = File.ReadAllText(path, Encoding.Default);
            var data = JsonSerializer.Deserialize<SpriteData>(jsonString);

            // Load non-animated block sprites
            foreach (var spriteData in data.nonanimated_block_sprites)
            {
                nonanimated_sprites[spriteData.name] = new Rectangle(spriteData.x, spriteData.y, spriteData.width, spriteData.height);
            }

            // Load animated block sprites
            foreach (var spriteData in data.animated_block_sprites)
            {
                animated_sprites[spriteData.name] = new Rectangle[]
                {
                    new Rectangle(spriteData.x1, spriteData.y1, spriteData.width, spriteData.height),
                    new Rectangle(spriteData.x2, spriteData.y2, spriteData.width, spriteData.height),
                    new Rectangle(spriteData.x3, spriteData.y3, spriteData.width, spriteData.height),
                    new Rectangle(spriteData.x4, spriteData.y4, spriteData.width, spriteData.height)
                };
            }
        }

        // Non-animated sprites
        public ISprite CreateNonAnimatedBlock(SpriteBatch spriteBatch, string spriteName, Vector2 position)
        {
            if (nonanimated_sprites.TryGetValue(spriteName, out Rectangle spriteRect))
            {
                return new NonAnimatedBlockSprite(blockTextures, spriteRect, position);
            }

            return null;
        }

        // Animated sprites
        public ISprite CreateAnimatedBlock(SpriteBatch spriteBatch, string spriteName, Vector2 position)
        {
            if (animated_sprites.TryGetValue(spriteName, out Rectangle[] spriteRects))
            {
                return new AnimatedBlockSprite(blockTextures, spriteRects, position);
            }

            return null;
        }
    }

    public class SpriteData
    {
        public List<SpriteInfo> nonanimated_block_sprites { get; set; }
        public List<SpriteInfo> animated_block_sprites { get; set; }
    }

    public class SpriteInfo
    {
        public string name { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int frames { get; set; }
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public int x3 { get; set; }
        public int y3 { get; set; }
        public int x4 { get; set; }
        public int y4 { get; set; }
    }
}