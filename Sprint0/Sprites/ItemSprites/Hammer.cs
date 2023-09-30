using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.Item_Sprites
{
    internal class Hammer : ISprite
    {
        private ItemSpriteFactory factory;
        private NonAniItemSprite sprite;
        private int width = 16;
        private int height = 16;

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Rectangle position = new Rectangle((int)sprite.position.X, (int)sprite.position.Y, width, height);

            //spriteBatch.Draw(factory.hammer, position, factory.hammerRect, Color.White);

        }
    }
}