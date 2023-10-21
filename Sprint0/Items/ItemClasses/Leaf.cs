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
    internal class Leaf : IItem
    {
        private Item item;
        private ItemSpriteFactory spriteFactory;

        public Leaf(Item item, ItemSpriteFactory spriteFactory)
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
            item.setLeaf();
            item.aniSprite = spriteFactory.returnSprite("Leaf");
        }
    }
}