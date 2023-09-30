using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;
using Microsoft.Xna.Framework.Content;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class TextSprite : ISprite
    {

        public void Draw(SpriteBatch spriteBatch, int width, int height, ContentManager Content)
        {
            SpriteFont font = Content.Load<SpriteFont>("Credits");

            spriteBatch.DrawString(font, "Credits\nProgram Made By: Scott Chen\nSprites From: https://www.mariouniverse.com/sprites-nes-smb2/", new Vector2(width * 2 / 10, height * 3 / 4), Color.Black);
        }

        public void Update()
        {
            //Nothing needed
        }

    }
}
