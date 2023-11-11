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
using Sprint0.Sprites.ItemSprites;

namespace Sprint0.Items
{
    internal class Tanooki : IItem
    {
        private AniItemSprite aniItem;
        private Vector2 position;
        public Rectangle Destination { get; set; }
        public bool moveRight { get; set; }
        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }

        public Tanooki()
        {
            aniItem = ItemSpriteFactory.Instance.returnSprite("Tanooki");
            Destination = aniItem.itemPosition;
            moveRight = false;
        }

        public void setPosition(List<int> pos)
        {
            position.X = pos[0];
            position.Y = pos[1];
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aniItem.Draw(spriteBatch, position);
        }
    }
}