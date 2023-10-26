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

namespace Sprint0.Items
{
    internal class Shoe : IItem
    {
        private AniItemSprite aniItem;
        private Vector2 position;

        public Shoe()
        {
            aniItem = ItemSpriteFactory.Instance.returnSprite("Shoe");
        }

        public void setPosition(List<int> pos)
        {
            position.X = pos[0];
            position.Y = pos[1];
        }

        public void Update(GameTime time)
        {
            aniItem.Update(time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aniItem.Draw(spriteBatch, position);
        }
    }
}