using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class MarioFireMoveLeftSprite : ISprite
    {
        private Sprint0 mySprint;
        private Mario mario;

        // Frame Stats
        private int CurrentFrame = 0;
        private int TotalFrames = 3;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 150;

        // Rectanlges
        private Rectangle[] spriteFrames;
        private Rectangle destination;

        public MarioFireMoveLeftSprite(Sprint0 Sprint0, Mario mario)
        {
            mySprint = Sprint0;
            spriteFrames = new Rectangle[] { new Rectangle(1, 263, 17, 28), new Rectangle(19, 263, 17, 28), new Rectangle(36, 0, 17, 28), new Rectangle(19, 263, 17, 28) };
            this.mario = mario;

        }

        public void Update()
        {
            timeSinceLastFrame += mySprint.myGameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                CurrentFrame++;
                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            destination = new Rectangle((int)mario.position.X, (int)mario.position.Y, 34, 56);
            spriteBatch.Draw(mario.marioTexture, destination, spriteFrames[CurrentFrame], Color.White);
        }
    }
}
