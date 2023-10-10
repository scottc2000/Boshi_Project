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
using System.Reflection;

namespace Sprint0.Sprites
{
    public class BlockSpriteFactory : ISpriteFactory
    {
        private Texture2D blockTextures;
        private Dictionary<string, Rectangle> _sprites;
        private static BlockSpriteFactory spriteFactory = new BlockSpriteFactory();
        private string fileName { get; set; }
        private string jsonString { get; set; }

        public static BlockSpriteFactory Instance
        {
            get => spriteFactory;
        }

        public BlockSpriteFactory()
        {
            _sprites = new Dictionary<string, Rectangle>();
        }

        public void LoadTextures(ContentManager content)
        {
            blockTextures = content.Load<Texture2D>("SpriteImages/blocks");
        }

        public void SaveSpriteLocations(ContentManager content) 
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..\\..\\..\\Sprites\\BlockData.json");
            jsonString = File.ReadAllText(path, Encoding.Default);
            BlockSpriteFactory deserializer = JsonSerializer.Deserialize<BlockSpriteFactory>(jsonString);
            //Non Animated Blocks
            _sprites.Add("gray_block", new Rectangle(2076, 274, 32, 32));
            _sprites.Add("wood_block", new Rectangle(2008, 36, 32, 32));
            _sprites.Add("empty_question_block", new Rectangle(2416, 2, 32, 32));

            //Animated Blocks
            _sprites.Add("question_block", new Rectangle(2280, 2, 32, 32));
            _sprites.Add("yellow_brick", new Rectangle(2076, 70, 32, 32));
            

        }

        // Non Animated Sprites
        public ISprite CreateGrayBlock(SpriteBatch spriteBatch, Vector2 position)
        {
            return new NonAnimatedBlockSprite(spriteBatch, blockTextures, _sprites["gray_block"], position);
        }

        public ISprite CreateWoodBlock(SpriteBatch spriteBatch, Vector2 position)
        {
            return new NonAnimatedBlockSprite(spriteBatch, blockTextures, _sprites["wood_block"], position);
        }

        public ISprite CreateEmptyQuestionBlock(SpriteBatch spriteBatch, Vector2 position)
        {
            return new NonAnimatedBlockSprite(spriteBatch, blockTextures, _sprites["empty_question_block"], position);
        }

        // Animated Sprites
        public ISprite CreateQuestionBlock(SpriteBatch spriteBatch, Vector2 position)
        {
            return new AnimatedBlockSprite(spriteBatch, blockTextures, _sprites["question_block"], 1, 4, position);
        }

        public ISprite CreateYellowBrickSprite(SpriteBatch spriteBatch, Vector2 position)
        {
            return new AnimatedBlockSprite(spriteBatch, blockTextures, _sprites["yellow_brick"], 1, 4, position);
        }
    }
}
