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

        private ISprite grayBlockSprite;
        private ISprite questionBlockSprite;
        private ISprite woodBlockSprite;
        private ISprite yellowBrickSprite;
        private ISprite emptyQuestionBlockSprite;

        public Vector2 location { get; set; }
        

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
            questionBlockSprite = BlockSpriteFactory.Instance.CreateQuestionBlock(spriteBatch, new Vector2(700, 100));
            woodBlockSprite = BlockSpriteFactory.Instance.CreateWoodBlock(spriteBatch, new Vector2(700, 100));
            yellowBrickSprite = BlockSpriteFactory.Instance.CreateYellowBrickSprite(spriteBatch, new Vector2(700, 100));
            emptyQuestionBlockSprite = BlockSpriteFactory.Instance.CreateEmptyQuestionBlock(spriteBatch, new Vector2(700, 100));
        }

        public void Update(GameTime gameTime)
        {
            questionBlockSprite.Update(gameTime);
            yellowBrickSprite.Update(gameTime);
        }

        public void Draw()
        {
            grayBlockSprite.Draw(spriteBatch, content);
            questionBlockSprite.Draw(spriteBatch, content);
            woodBlockSprite.Draw(spriteBatch, content);
            yellowBrickSprite.Draw(spriteBatch, content);
            emptyQuestionBlockSprite.Draw(spriteBatch, content);
        }
    }
}
