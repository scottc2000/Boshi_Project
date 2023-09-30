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

        public Rectangle[] spriteFrames;

        Vector2 position;
        Rectangle destination;
        float rotation = 0, layer = 0;
        SpriteEffects right;

        public LuigiStill()
        {
            right = SpriteEffects.None;

            position.X = 400;
            position.Y = 240;

            spriteFrames = new Rectangle[] {new Rectangle(1,179, 17, 28) };
        }
        public void Update(GameTime gameTime)
        {
            //Nothing needed here
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            Texture2D Texture = Content.Load<Texture2D>("SpriteImages/playerssclear");

            destination = new Rectangle((int)position.X, (int)position.Y, 34, 56);

            spriteBatch.Draw(Texture, destination, spriteFrames[0], Color.White, rotation, new Vector2(0, 0), right, layer);

        }
    }
}
