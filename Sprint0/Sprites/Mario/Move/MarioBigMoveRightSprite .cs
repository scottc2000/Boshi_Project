using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class MarioBigMoveRightSprite : ISprite
    {
        private Sprint0 mySprint;
        private Mario mario;

        // Frame Stats
        private int currentFrame = 0;
        private int totalFrames = 3;
        private double frameSpeed = 0.2;

        // Rectanlges
        private Rectangle[] spriteFrames;
        private Rectangle destination;

        public MarioBigMoveRightSprite(Sprint0 Sprint0, Mario mario)
        {
            mySprint = Sprint0;
            spriteFrames = new Rectangle[] { new Rectangle(1, 92, 17, 28), new Rectangle(19, 92, 17, 28), new Rectangle(36, 92, 17, 28), new Rectangle(19, 92, 17, 28) };
            this.mario = mario;
        }
        public void Update(GameTime gametime)
        {

            // Frame buffer : http://rbwhitaker.wikidot.com/forum/t-398346/animated-sprite-speed-display
            currentFrame = (int)(gametime.TotalGameTime.TotalSeconds / frameSpeed);
            currentFrame = currentFrame % totalFrames;

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            destination = new Rectangle((int)mario.position.X, (int)mario.position.Y, 34, 56);

            // Overload parameters to flip sprite horizontally
            SpriteEffects right = SpriteEffects.FlipHorizontally;
            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(mario.marioTexture, destination, spriteFrames[currentFrame], Color.White, rotation, new Vector2(0,0), right, layer);
        }

    }
}
