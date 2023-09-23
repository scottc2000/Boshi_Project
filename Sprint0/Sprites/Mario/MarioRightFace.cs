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

namespace Sprint0.Sprites
{
    internal class MarioRightFace : ISprite
    {
        private Sprint0 mySprint0;
        private Texture2D marioMovingRight;

        // Rectanlges
        private Rectangle spriteFrame;
        private Rectangle destination;

        public MarioRightFace(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
            spriteFrame = new Rectangle(1, 92, 17, 28);
            destination = new Rectangle(150, 150, 34, 56);
        }
        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            marioMovingRight = Content.Load<Texture2D>("SpriteImages/playerssclear");

            // Overload parameters to flip sprite horizontally
            SpriteEffects right = SpriteEffects.FlipHorizontally;
            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(marioMovingRight, destination, spriteFrame, Color.White, rotation, new Vector2(0,0), right, layer);
        }

    }
}
