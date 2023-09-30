using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites
{
    internal class NonAniItemSprite : ISprite
    {
        ItemSpriteFactory factory;
        Item item;
        String itemString;
        private int width = 16, height = 16;

        public NonAniItemSprite(ItemSpriteFactory factory, Item item, String itemString)
        {
            this.factory = factory;
            this.itemString = itemString;
            this.item = item;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle position = new Rectangle((int)item.position.X, (int)item.position.Y, width, height);
            spriteBatch.Draw(factory.texture, position, factory.itemAndRectangle[itemString], Color.White);
        }
    }
}
