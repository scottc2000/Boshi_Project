using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sprint0.Sprites.Item_Sprites
{
    internal class OneUpMushroom : IItem, ISprite
    {
        private Item item;
        private ItemSpriteFactory spriteFactory;

        public OneUpMushroom(Item item, ItemSpriteFactory spriteFactory)
        {
            this.item = item;
            this.spriteFactory = spriteFactory;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            item.setOneUpMushroom();
            item.aniSprite = spriteFactory.returnSprite("OneUpMushroom");
        }
    }
}