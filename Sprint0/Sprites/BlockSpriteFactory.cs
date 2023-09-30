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

namespace Sprint0.Sprites
{
    public class BlockSpriteFactory : ISpriteFactory
    {
        private Texture2D blockTextures;
        private Dictionary<string, Rectangle> _sprites;
        private static BlockSpriteFactory spriteFactory = new BlockSpriteFactory();

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
