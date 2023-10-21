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
    internal class Hammer : ISprite
    {
        private ItemSpriteFactory spriteFactory;
        private Item item;

        public Hammer(Item item, ItemSpriteFactory spriteFactory)
        {
            this.item = item;
            this.spriteFactory = spriteFactory;
        }

        public void Update(GameTime gameTime)
        {
            item.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            item.setHammer();
            item.aniSprite = spriteFactory.returnSprite("Hammer");
        }
    }
}