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

namespace Sprint0.Sprites
{
    internal class MarioFireRightIdleSprite : ISprite
    {
        private Sprint0 mySprint;
        private Texture2D marioMovingRight;

        // Rectanlges
        private Rectangle spriteFrame;
        private Rectangle destination;

        public MarioFireRightIdleSprite(Sprint0 Sprint0)
        {
            mySprint = Sprint0;
            spriteFrame = new Rectangle(1, 263, 17, 28);
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            marioMovingRight = mySprint.Content.Load<Texture2D>("SpriteImages/playerssclear");

            destination = new Rectangle((int)location.X, (int)location.Y, 34, 56);

            // Overload parameters to flip sprite horizontally
            SpriteEffects right = SpriteEffects.FlipHorizontally;
            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(marioMovingRight, destination, spriteFrame, Color.White, rotation, new Vector2(0,0), right, layer);
        }

    }
}
