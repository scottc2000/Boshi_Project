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
using Sprint0.Characters;

namespace Sprint0.Sprites
{
    internal class MarioBigCrouchLeftSprite : ISprite
    {
        private Sprint0 mySprint;
        private Mario mario;

        // Rectangles
        private Rectangle spriteFrames;
        private Rectangle position;

        public MarioBigCrouchLeftSprite(Sprint0 Sprint0, Mario mario)
        {
            mySprint = Sprint0;
            spriteFrames = new Rectangle(54, 92, 17, 28);
            this.mario = mario;
        }
        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            position = new Rectangle((int)mario.position.X, (int)mario.position.Y, 34, 56);

            spriteBatch.Draw(mario.marioTexture, position, spriteFrames, Color.White);
        }

    }
}
