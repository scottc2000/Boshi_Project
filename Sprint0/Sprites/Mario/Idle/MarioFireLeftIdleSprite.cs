using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class MarioFireLeftIdleSprite : ISprite
    {
        private Sprint0 mySprint;
        private Mario mario;

        private Rectangle spriteFrame;
        private Rectangle position;
        public MarioFireLeftIdleSprite(Sprint0 sprint0, Mario mario)
        {
            mySprint = sprint0;
            spriteFrame = new Rectangle(1, 263, 17, 28);
            this.mario = mario;
            
        }
        public void Update (GameTime gametime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            position = new Rectangle((int)mario.position.X, (int)mario.position.Y, 34, 56);
            spriteBatch.Draw(mario.marioTexture, position, new Rectangle(1, 90, 17, 28), Color.White);

        }
    }
}