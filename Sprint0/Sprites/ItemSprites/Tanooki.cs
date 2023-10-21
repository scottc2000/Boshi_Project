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
    internal class Tanooki : ISprite
    {
        private Item item;
        private ItemSpriteFactory spriteFactory;

        public Tanooki(Item item, ItemSpriteFactory spriteFactory)
        {
            this.item = item;
            this.spriteFactory = spriteFactory;
        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            item.setToonki();
            item.aniSprite = spriteFactory.returnSprite("Tanooki");
        }
    }
}