using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.Items.ItemClasses
{
    internal class FireFlower : IItem
    {
        private ItemSpriteFactory spriteFactory;
        private Item item;

        public FireFlower(Item item, ItemSpriteFactory spriteFactory)
        {
            this.spriteFactory = spriteFactory;
            this.item = item;
        }

        public void Update(GameTime gameTime)
        {
            item.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            item.setFireFlower();
            item.aniSprite = spriteFactory.returnSprite("FireFlower");

        }
    }
}