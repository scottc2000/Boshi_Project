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
using Sprint0.Sprites.ItemSprites;

namespace Sprint0.Sprites.Item_Sprites
{
    internal class FireFlower : IItem, ISprite
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

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            item.setFireFlower();
            item.aniSprite = spriteFactory.returnSprite("FireFlower");

        }
    }
}