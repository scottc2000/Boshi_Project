using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Blocks
{
    internal class YellowBrick : IBlock
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
        private int totalFrames;
        private float frameTimer;
        private float frameInterval;

        public YellowBrick(SpriteBatch spriteBatch, Rectangle blockRectangle)
        {
            Destination = blockRectangle;
            sprite = BlockSpriteFactory.Instance.CreateNonAnimatedBlock(spriteBatch, "yellow_brick", new Vector2(blockRectangle.X, blockRectangle.Y));
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Bump(GameTime gameTime)
        {
            frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (frameTimer >= frameInterval)
            {
                for (int i = 0; i < totalFrames / 2; i++)
                {
                    Destination = new Rectangle(Destination.X, Destination.Y - 2 * (i + 1), Destination.Width, Destination.Height);
                }
                for (int i = totalFrames / 2; i > 0 / 2; i--)
                {
                    Destination = new Rectangle(Destination.X, Destination.Y + 2 * (i + 1), Destination.Width, Destination.Height);
                }
                frameTimer = 0f;
            }
        }

    }
}