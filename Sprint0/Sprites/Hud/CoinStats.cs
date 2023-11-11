﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using Sprint0.Interfaces;

namespace Sprint0.Sprites.Hud
{
    public class CoinStats : ISprite
    {
        private Texture2D texture;
        private Vector2 size;

        private Rectangle spriteFrame;
        private Rectangle destination;

        public CoinStats(Texture2D sheet, Vector2 position, Vector2 size)
        {
            texture = sheet;
            this.size = size;
            spriteFrame = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destination = new Rectangle((int)location.X, (int)location.Y, (int)size.X * 2, (int)size.Y * 2);

            spriteBatch.Draw(texture, destination, spriteFrame, Color.White);
        }
        public void Update(GameTime gametime)
        {
            
        }
    }
}