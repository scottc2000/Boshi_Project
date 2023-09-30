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

namespace Sprint0.Blocks
{
    public class Block: IBlock
    {
        private Sprint0 game;
        private SpriteBatch spriteBatch;
        private ContentManager content;
        private List<ISprite> blocks = new List<ISprite>();

        private ISprite grayBlockSprite;
        private ISprite questionBlockSprite;
        private ISprite woodBlockSprite;
        private ISprite yellowBrickSprite;
        private ISprite emptyQuestionBlockSprite;

        public Vector2 location { get; set; }
        private int blockCount;
        private int blockIndex;
        

        public Block(Sprint0 game, SpriteBatch spriteBatch, ContentManager content)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.content = content;
            
        }

        public void LoadBlocks()
        {
            BlockSpriteFactory.Instance.LoadTextures(content);
            BlockSpriteFactory.Instance.SaveSpriteLocations(content);

            grayBlockSprite = BlockSpriteFactory.Instance.CreateGrayBlock(spriteBatch, new Vector2(700, 100));
            blocks.Add(grayBlockSprite);
            questionBlockSprite = BlockSpriteFactory.Instance.CreateQuestionBlock(spriteBatch, new Vector2(700, 100));
            blocks.Add(questionBlockSprite);
            woodBlockSprite = BlockSpriteFactory.Instance.CreateWoodBlock(spriteBatch, new Vector2(700, 100));
            blocks.Add(woodBlockSprite);
            yellowBrickSprite = BlockSpriteFactory.Instance.CreateYellowBrickSprite(spriteBatch, new Vector2(700, 100));
            blocks.Add(yellowBrickSprite);
            emptyQuestionBlockSprite = BlockSpriteFactory.Instance.CreateEmptyQuestionBlock(spriteBatch, new Vector2(700, 100));
            blocks.Add(emptyQuestionBlockSprite);

            blockCount = blocks.Count;
            blockIndex = 0;
        }

        public void Update(GameTime gameTime)
        {
            questionBlockSprite.Update(gameTime);
            yellowBrickSprite.Update(gameTime);
        }

        public void Draw()
        {
            switch(blockIndex)
            {
                case 0:
                    grayBlockSprite.Draw(spriteBatch, content);
                    break;
                case 4:
                    questionBlockSprite.Draw(spriteBatch, content);
                    break;
                case 1:
                    woodBlockSprite.Draw(spriteBatch, content);
                    break;
                case 3:
                    yellowBrickSprite.Draw(spriteBatch, content);
                    break;
                case 2:
                    emptyQuestionBlockSprite.Draw(spriteBatch, content);
                    break;
            }
            
        }

        public void IncrementBlockIndex()
        {
            blockIndex++;
            if(blockIndex >= blockCount)
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
