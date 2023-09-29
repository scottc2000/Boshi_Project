using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class MarioMoveLeftSprite : ISprite
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
       // private Vector2 position;

        public MarioMoveLeftSprite(Sprint0 Sprint0, Mario mario)
        {
            mySprint = Sprint0;
            spriteFrames = new Rectangle[] { new Rectangle(1, 15, 17, 17), new Rectangle(19, 15, 17, 17), new Rectangle(36, 15, 17, 17), new Rectangle(19, 15, 17, 17) };
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

            destination = new Rectangle((int)mario.position.X, (int)mario.position.Y, 20, 28);
            spriteBatch.Draw(mario.marioTexture, destination, spriteFrames[currentFrame], Color.White);
        }
    }
}
