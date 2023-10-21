using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.ItemSprites;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.Items
{
    public class Item : IItem
    {
        public enum ItemSelect { RedMushroom, OneUpMushroom, FireFlower, Leaf, Star, Frog, Tanooki, Hammer, Shoe };
        public Vector2 position;
        private Vector2 gravity;
        private Vector2 velocity;

        public AniItemSprite aniSprite;
        //private NonAniItemSprite nonAniSprite;
        private ISprite RedMushroomItem;
        private ISprite OneUpMushroomItem;
        private ISprite FireFlowerItem;
        private ISprite LeafItem;
        private ISprite StarItem;
        private ISprite FrogItem;
        private ISprite TanookiItem;
        private ISprite HammerItem;
        private ISprite ShoeItem;
        private ItemSpriteFactory spriteFactory;

        //private int itemIndex = 0;
        private int itemCount;
        public ItemSelect itemSelect;

        private float timer = 0f;
        private int interval = 50;
        private int itemSpeed = 3;
        private bool moveRight = false;

        public Item(Sprint0 game, GameTime gametime)
        {
            position = new Vector2(100, 100);
            spriteFactory = new ItemSpriteFactory(this);
            //spriteFactory.RegisterSprite();
            spriteFactory.LoadTextures(game.Content);
            itemCount += spriteFactory.itemAndRectangle.Count;
            itemCount += spriteFactory.itemAndFrames.Count;
            aniSprite = spriteFactory.returnSprite("RedMushroom");
            itemSelect = ItemSelect.RedMushroom;
            //nonAniSprite = new NonAniItemSprite(spriteFactory, this, "RedMushroom");

        }

        /*
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
        */

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

        /*
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
        */

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
            aniSprite.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            /*
            switch (itemSelect)
            {
                case 0:
                    RedMushroom.Draw(spriteBatch, position);
                    itemSelect = ItemSelect.RedMushroom;
                    break;
                case 1:
                    OneUpMushroom.Draw(spriteBatch, position);
                    itemSelect = ItemSelect.OneUpMushroom;
                    break;
                case 2:
                    Leaf.Draw(spriteBatch, position);
                    itemSelect = ItemSelect.Leaf;
                    break;
                case 3:
                    FireFlower.Draw(spriteBatch, position);
                    itemSelect = ItemSelect.FireFlower;
                    break;
                case 4:
                    Star.Draw(spriteBatch, position);
                    itemSelect = ItemSelect.Star;
                    break;
                case 5:
                    Frog.Draw(spriteBatch, position);
                    itemSelect = ItemSelect.Frog;
                    break;
                case 6:
                    Tanooki.Draw(spriteBatch, position);
                    itemSelect = ItemSelect.Tanooki;
                    break;
                case 7:
                    Hammer.Draw(spriteBatch, position);
                    itemSelect = ItemSelect.Hammer;
                    break;
                case 8:
                    Shoe.Draw(spriteBatch, position);
                    itemSelect = ItemSelect.Shoe;
                    break;
            }
            */
            aniSprite.Draw(spriteBatch);
        }
    }
}