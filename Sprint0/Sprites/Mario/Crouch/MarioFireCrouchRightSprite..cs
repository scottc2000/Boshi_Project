using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class MarioFireCrouchRightSprite : ISprite
    {
        private Sprint0 mySprint;
        private Mario mario;

        // Rectangles
        private Rectangle spriteFrame;
        private Rectangle position;

        public MarioFireCrouchRightSprite(Sprint0 Sprint0, Mario mario)
        {
            mySprint = Sprint0;
            spriteFrame = new Rectangle(54, 263, 17, 28);
            this.mario = mario;
        }
        public void Update(GameTime gametime)
        {
 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            position = new Rectangle((int)mario.position.X, (int)mario.position.Y, 34, 56);

            // Overload parameters to flip sprite horizontally
            SpriteEffects right = SpriteEffects.FlipHorizontally;
            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(mario.marioTexture, position, spriteFrame, Color.White, rotation, new Vector2(0,0), right, layer);
        }

    }
}
