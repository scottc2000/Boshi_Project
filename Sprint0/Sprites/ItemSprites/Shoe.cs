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
    internal class Shoe : ISprite
    {
        private ItemSpriteFactory spriteFactory;
        private Item item;

        public Shoe(Item item, ItemSpriteFactory spriteFactory)
        {
            this.item = item;
            this.spriteFactory = spriteFactory;
        }

        public void Update(GameTime time)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            item.setShoe();
            item.aniSprite = spriteFactory.returnSprite("Shoe");
        }
    }
}