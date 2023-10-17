using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Items;
using Sprint0.Sprites.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.ItemSprites
{
    internal class NonAniItemSprite : ISprite
    {
        ItemSpriteFactory factory;
        Item item;
        string itemString;
        private int width = 16, height = 16;

        public NonAniItemSprite(ItemSpriteFactory factory, Item item, string itemString)
        {
            this.factory = factory;
            this.itemString = itemString;
            this.item = item;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle position = new Rectangle((int)item.position.X, (int)item.position.Y, width, height);
            spriteBatch.Draw(factory.texture, position, factory.itemAndRectangle[itemString], Color.White);
        }
    }
}