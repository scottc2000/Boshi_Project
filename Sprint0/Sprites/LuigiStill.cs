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
    internal class LuigiStill : ISprite
    {

        public LuigiStill()
        {

        }
        public void Update()
        {
            //Nothing needed here
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            Texture2D stillLuigi = Content.Load<Texture2D>("SpriteImages/playerssclear");

            spriteBatch.Draw(stillLuigi, new Vector2(400, 240), new Rectangle(1, 178, 17, 28), Color.White);

        }
    }
}
