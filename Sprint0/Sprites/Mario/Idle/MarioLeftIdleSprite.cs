using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Sprint0.Characters;

namespace Sprint0.Sprites
{
    internal class MarioLeftIdleSprite : ISprite
    {
        private Sprint0 mySprint;
        private Mario mario;

        private Rectangle spriteFrame;
        private Rectangle position;
        public MarioLeftIdleSprite(Sprint0 sprint0, Mario mario)
        {
            spriteFrame = new Rectangle(1, 15, 17, 17);
            mySprint = sprint0;
            this.mario = mario;
        }
        public void Update(GameTime gametime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            position = new Rectangle((int)mario.position.X, (int)mario.position.Y, 20, 28);
            spriteBatch.Draw(mario.marioTexture, position, spriteFrame, Color.White);

        }
    }
}