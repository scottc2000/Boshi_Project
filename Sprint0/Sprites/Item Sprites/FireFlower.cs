﻿using Microsoft.Xna.Framework.Content;
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
    internal class FireFlower : ISprite
    {
        private ItemSpriteFactory factory;
        private NonAniItemSprite sprite;
        private int width = 16;
        private int height = 16;
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Rectangle position = new Rectangle((int)sprite.position.X, (int)sprite.position.Y, width, height);

            //spriteBatch.Draw(factory.fireFlower, position, factory.fireFlowerRect, Color.White);

        }
    }
}