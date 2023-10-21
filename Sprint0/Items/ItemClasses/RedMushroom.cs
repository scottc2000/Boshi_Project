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

namespace Sprint0.Items.ItemClasses
{
    internal class RedMushroom : IItem
    {
        private Item item;
        private ItemSpriteFactory spriteFactory;
        public RedMushroom(Item item, ItemSpriteFactory spriteFactory)
        {
            this.item = item;
            this.spriteFactory = spriteFactory;
        }

        public void Update(GameTime gameTime)
        {
            item.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            item.setRedMushroom();
            item.aniSprite = spriteFactory.returnSprite("RedMushroom");
        }
    }
}
