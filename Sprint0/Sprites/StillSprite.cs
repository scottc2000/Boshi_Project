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
    internal class StillSprite : ISprite
    {

        public StillSprite()
        {

        }
        public void Update()
        {
            //Nothing needed here
        }

        public void Draw(SpriteBatch spriteBatch, int width, int height, ContentManager Content)
        {
            Texture2D stillLuigi = Content.Load<Texture2D>("luigiStill");

            spriteBatch.Draw(stillLuigi, new Rectangle(width * 4 / 10, height * 2 / 10, 90, 175), Color.White);
        }
    }
}
