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

namespace Sprint0.Sprites
{
    internal class MarioLeftIdleSprite : ISprite
    {
        private Sprint0 mySprint;
        private Texture2D stillMario;
        private Rectangle spriteFrame;
        private Rectangle position;
        public MarioLeftIdleSprite(Sprint0 sprint0)
        {
            spriteFrame = new Rectangle(1, 0, 17, 28);
            position = new Rectangle(150, 150, 34, 56);
            mySprint = sprint0;
        }
        public void Update()
        {
            //Nothing needed here
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            Texture2D stillMario = Content.Load<Texture2D>("SpriteImages/playerssclear");

            spriteBatch.Draw(stillMario, position, new Rectangle(1, 90, 17, 28), Color.White);

        }
    }
}