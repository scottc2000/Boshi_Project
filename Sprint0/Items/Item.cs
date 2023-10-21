﻿using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.Items.ItemClasses;

namespace Sprint0.Items
{
    public class Item : IItem
    {
        public enum ItemSelect { RedMushroom, OneUpMushroom, FireFlower, Leaf, Star, Frog, Tanooki, Hammer, Shoe };
        public Vector2 position;
        private Vector2 gravity;
        private Vector2 velocity;

        public AniItemSprite aniSprite;
        private ItemSpriteFactory spriteFactory;

        public ItemSelect itemSelect;

        private float timer = 0f;
        private int interval = 15;
        private int itemSpeed = 1;
        private bool moveRight = false;

        public Item(Sprint0 game, GameTime gametime)
        {
            position = new Vector2(100, 100);
            spriteFactory = new ItemSpriteFactory(this);
            spriteFactory.LoadTextures(game.Content);
            aniSprite = spriteFactory.returnSprite("RedMushroom");
            itemSelect = ItemSelect.RedMushroom;

        }


        public void setRedMushroom()
        {
            itemSelect = ItemSelect.RedMushroom;
        }

        public void setOneUpMushroom()
        {
            itemSelect = ItemSelect.OneUpMushroom;
        }

        public void setFireFlower()
        {
            itemSelect = ItemSelect.FireFlower;
        }

        public void setLeaf()
        {
            itemSelect = ItemSelect.Leaf;
        }

        public void setStar()
        {
            itemSelect = ItemSelect.Star;
        }

        public void setFrog()
        {
            itemSelect = ItemSelect.Frog;
        }

        public void setToonki()
        {
            itemSelect = ItemSelect.Tanooki;
        }

        public void setHammer()
        {
            itemSelect = ItemSelect.Hammer;
        }

        public void setShoe()
        {
            itemSelect = ItemSelect.Shoe;
        }

        public void UpdatePos(GameTime gameTime)
        {
            switch (itemSelect)
            {
                case ItemSelect.RedMushroom:
                case ItemSelect.OneUpMushroom:
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (timer > interval && moveRight)
                    {
                        position.X += itemSpeed;
                        timer = 0;
                        if (position.X >= 800 - 16) moveRight = false;
                    }
                    else if (timer > interval && !moveRight)
                    {
                        position.X -= itemSpeed;
                        timer = 0;
                        if (position.X <= 0) moveRight = true;
                    }
                    break;

            }
        }

        public void Update(GameTime gameTime)
        {
            aniSprite.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aniSprite.Draw(spriteBatch);
        }
    }
}