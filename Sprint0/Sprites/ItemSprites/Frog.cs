using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.Sprites.ItemSprites;

namespace Sprint0.Sprites.Item_Sprites
{
    internal class Frog : IItem, ISprite
    {
        private ItemSpriteFactory spriteFactory;
        private Item item;
        
        public Frog(Item item, ItemSpriteFactory spriteFactory)
        {
            this.item = item;
            this.spriteFactory = spriteFactory;
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            item.setFrog();
            item.aniSprite = spriteFactory.returnSprite("Frog");
        }
    }
}