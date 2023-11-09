using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Blocks
{
    internal class QuestionBlock : IBlock
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        private ISprite sprite;
        private Vector2 location { get; set; }
        public Rectangle Destination { get; set; }
        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }


        public QuestionBlock(SpriteBatch spriteBatch, ContentManager content, Rectangle blockRectangle, int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            Destination = blockRectangle;
            BlockSpriteFactory.Instance.LoadTextures(content);
            BlockSpriteFactory.Instance.LoadSpriteLocations();
            sprite = BlockSpriteFactory.Instance.CreateAnimatedBlock(spriteBatch, "question_block", new Vector2(blockRectangle.X, blockRectangle.Y));
        }


        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}