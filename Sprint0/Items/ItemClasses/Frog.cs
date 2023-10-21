﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.Items.ItemClasses
{
    internal class Frog : IItem
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
            item.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            item.setFrog();
            item.aniSprite = spriteFactory.returnSprite("Frog");
        }
    }
}