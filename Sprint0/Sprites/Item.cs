using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    public class Item
    {
        public enum ItemSelect { RedMushroom, OneUpMushroom, FireFlower, Leaf, Star, Frog, Tanooki, Hammer, Shoe };
        public Vector2 position;

        private AniItemSprite aniSprite;
        private NonAniItemSprite nonAniSprite;
        private ISprite RedMushroom;
        private ISprite OneUpMushroom;
        private ISprite FireFlower;
        private ISprite Leaf;
        private ISprite Star;
        private ISprite Frog;
        private ISprite Tanooki;
        private ISprite Hammer;
        private ISprite Shoe;
        private ItemSpriteFactory spriteFactory;

        private int itemIndex = 0;
        private int itemCount;
        private ItemSelect itemSelect;

        private float timer = 0f;
        private int interval = 50;
        private int itemSpeed = 3;
        private bool moveRight = true;

        public Item(Sprint0 game, GameTime gametime)
        {
            position = new Vector2(100, 100);
            spriteFactory = new ItemSpriteFactory(game.Content, this, gametime);
            spriteFactory.RegisterSprite();
            spriteFactory.LoadTextures();
            itemCount += spriteFactory.itemAndRectangle.Count;
            itemCount += spriteFactory.itemAndFrames.Count;
            aniSprite = new AniItemSprite(spriteFactory, this, "Star");
            nonAniSprite = new NonAniItemSprite(spriteFactory, this, "RedMushroom");

        }

        public void LoadItems()
        {
            RedMushroom = spriteFactory.createRedMushroom();
            OneUpMushroom = spriteFactory.createOneUpMushroom();
            FireFlower = spriteFactory.createFireFlower();
            Leaf = spriteFactory.createLeaf();
            Star = spriteFactory.createStar();
            Frog = spriteFactory.createFrog();
            Tanooki = spriteFactory.createTanooki();
            Hammer = spriteFactory.createHammer();
            Shoe = spriteFactory.createShoe();

        }

        public void incrementItem()
        {
            itemIndex++;
            if (itemIndex >= itemCount)
            {
                itemIndex = 0;
            }
        }

        public void decrementItem()
        {
            itemIndex--;
            if (itemIndex < 0)
            {
                itemIndex = itemCount - 1;
            }
        }

        public void UpdatePos(GameTime gameTime)
        {
            switch (itemSelect)
            {
                case ItemSelect.RedMushroom:
                case ItemSelect.OneUpMushroom:
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
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
            Shoe.Update(gameTime);
            Star.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (itemIndex)
            {
                case 0:
                    RedMushroom.Draw(spriteBatch);
                    itemSelect = ItemSelect.RedMushroom;
                    break;
                case 1:
                    OneUpMushroom.Draw(spriteBatch);
                    itemSelect = ItemSelect.OneUpMushroom;
                    break;
                case 2:
                    Leaf.Draw(spriteBatch);
                    itemSelect = ItemSelect.Leaf;
                    break;
                case 4:
                    Star.Draw(spriteBatch);
                    itemSelect = ItemSelect.Star;
                    break;
                case 5:
                    Frog.Draw(spriteBatch);
                    itemSelect = ItemSelect.Frog;
                    break;
                case 6:
                    Tanooki.Draw(spriteBatch);
                    itemSelect = ItemSelect.Tanooki;
                    break;
                case 7:
                    Hammer.Draw(spriteBatch);
                    itemSelect = ItemSelect.Hammer;
                    break;
                case 8:
                    Shoe.Draw(spriteBatch);
                    itemSelect = ItemSelect.Shoe;
                    break;
            }
        }
    }
}