using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.Blocks
{
    public class Sprint2Block : IBlock
    {
        private Sprint0 game;
        private SpriteBatch spriteBatch;
        private ContentManager content;
        private List<ISprite> blocks = new List<ISprite>();

        private ISprite sprite1;
        private ISprite sprite2;
        private ISprite sprite3;
        private ISprite sprite4;
        private ISprite sprite5;

        public Vector2 location { get; set; }
        private int blockCount;
        private int blockIndex;


        public Sprint2Block(Sprint0 game, SpriteBatch spriteBatch, ContentManager content)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.content = content;

        }

        public void LoadBlocks()
        {
            BlockSpriteFactory.Instance.LoadTextures(content);
            BlockSpriteFactory.Instance.LoadSpriteLocations(content);

            sprite1 = BlockSpriteFactory.Instance.CreateNonAnimatedBlock(spriteBatch, "wood_floor_middle", new Vector2(700, 100));
            blocks.Add(sprite1);
            sprite2 = BlockSpriteFactory.Instance.CreateAnimatedBlock(spriteBatch, "question_block", new Vector2(700, 100));
            blocks.Add(sprite2);
            sprite3 = BlockSpriteFactory.Instance.CreateNonAnimatedBlock(spriteBatch, "wood_side_left", new Vector2(700, 100));
            blocks.Add(sprite3);
            sprite4 = BlockSpriteFactory.Instance.CreateAnimatedBlock(spriteBatch, "flashing_yellow_brick", new Vector2(700, 100));
            blocks.Add(sprite4);
            sprite5 = BlockSpriteFactory.Instance.CreateNonAnimatedBlock(spriteBatch, "wood_side_right", new Vector2(700, 100));
            blocks.Add(sprite5);

            blockCount = blocks.Count;
            blockIndex = 0;
        }

        public void Update(GameTime gameTime)
        {
            sprite2.Update(gameTime);
            sprite4.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (blockIndex)
            {
                case 0:
                    sprite1.Draw(spriteBatch, location);
                    break;
                case 1:
                    sprite2.Draw(spriteBatch, location);
                    break;
                case 2:
                    sprite3.Draw(spriteBatch, location);
                    break;
                case 3:
                    sprite4.Draw(spriteBatch, location);
                    break;
                case 4:
                    sprite5.Draw(spriteBatch, location);
                    break;
            }

        }

        public void IncrementBlockIndex()
        {
            blockIndex++;
            if (blockIndex >= blockCount)
            {
                blockIndex = 0;
            }
        }

        public void DecrementBlockIndex()
        {
            blockIndex--;
            if (blockIndex < 0)
            {
                blockIndex = blockCount - 1;
            }
        }
    }

}