using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.Items
{
    internal class AniItemSprite : ISprite
    {
        private float timer = 0;
        private int interval = 50;
        private int currentFrame = 0;
        public Rectangle[] spriteFrames;
        public Rectangle itemPosition;

        public AniItemSprite(Rectangle[] currentFrames)
        {
            spriteFrames = currentFrames;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                currentFrame++;
                timer = 0;
                if (currentFrame == spriteFrames.Length) currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            itemPosition = new Rectangle((int)location.X, (int)location.Y, spriteFrames[currentFrame].Width, spriteFrames[currentFrame].Height);
            spriteBatch.Draw(ItemSpriteFactory.Instance.texture, itemPosition, spriteFrames[currentFrame], Color.White);
        }
    }
}