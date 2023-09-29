using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Input;
using System.Data.Common;
using Sprint0.Characters;

namespace Sprint0.Sprites
{
    internal class MarioFireRightIdleSprite : ISprite
    {
        private Sprint0 mySprint;
        private Mario mario;

        // Rectanlges
        private Rectangle spriteFrame;
        private Rectangle destination;

        public MarioFireRightIdleSprite(Sprint0 Sprint0, Mario mario)
        {
            mySprint = Sprint0;
            spriteFrame = new Rectangle(1, 263, 17, 28);
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
