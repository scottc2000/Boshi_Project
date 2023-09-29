using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class MarioFireJumpLeftSprite : ISprite
    {
        private Sprint0 mySprint;
        private Mario mario;

        // Rectangle stats
        private Rectangle spriteFrame;
        private Rectangle destination;

        public MarioFireJumpLeftSprite(Sprint0 mySprint0, Mario mario)
        {
            spriteFrame = new Rectangle(72, 263, 17, 28);
            mySprint = mySprint0;
            this.mario = mario;
        }
        public void Update(GameTime gametime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            destination = new Rectangle((int)mario.position.X, (int)mario.position.Y, 34, 56);
            spriteBatch.Draw(mario.marioTexture, destination, spriteFrame, Color.White);
        }

    }
}
