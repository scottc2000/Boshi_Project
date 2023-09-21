using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class MovingSprite : ISprite
    {
        int x = 400, y = 240;
        bool up = true;
        public MovingSprite()
        {

        }
        public void Update()
        {
            if (up)
            {
                y--;
            }
            else
            {
                y++;
            }

            if (y < 50)
                up = false;
            if (y > 250)
            {
                up = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            Texture2D deadLuigi = Content.Load<Texture2D>("SpriteImages/playerssclear");

            spriteBatch.Draw(deadLuigi, new Vector2(x, y), new Rectangle(307, 52, 16, 16), Color.White);
        }

    }
}
