using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.ItemSprites
{
    internal class RedMushroom : IItem, ISprite
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

        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            item.setRedMushroom();
            item.aniSprite = spriteFactory.returnSprite("RedMushroom");
        }
    }
}
