using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class MarioBigJumpRightSprite : ISprite
    {
        private Sprint0 mySprint;
        private Mario mario;

        // Rectangle stats
        private Rectangle spriteFrame;
        private Rectangle destination;

        public MarioBigJumpRightSprite(Sprint0 mySprint0, Mario mario)
        {
            spriteFrame = new Rectangle(72, 92, 17, 28);
            mySprint = mySprint0;
            this.mario = mario;
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            destination = new Rectangle((int)mario.position.X, (int)mario.position.Y, 34, 56);

            // Overload parameters to flip sprite horizontally
            SpriteEffects right = SpriteEffects.FlipHorizontally;
            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(mario.marioTexture, destination, spriteFrame, Color.White, rotation, new Vector2(0,0), right, layer);
        }

    }
}
