using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;

namespace Sprint0.Sprites.Item_Sprites
{
    internal class Star : IItem, ISprite
    {
        private Item item;
        private ItemSpriteFactory spriteFactory;

        public Star(Item item, ItemSpriteFactory spriteFactory)
        {
            this.item = item;
            this.spriteFactory = spriteFactory;
        }

        public void Update(GameTime time)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            item.setStar();
            item.aniSprite = spriteFactory.returnSprite("Star");

        }
    }
}