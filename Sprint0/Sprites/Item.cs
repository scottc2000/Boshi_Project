using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public class Item
    {
        public enum ItemSelect { RedMushroom, OneUpMushroom, FireFlower, Leaf, Star, Frog, Tanooki, Hammer, Shoe};
        public Vector2 position;
        public Sprint0 myGame;
        private AniItemSprite aniSprite;
        private NonAniItemSprite nonAniSprite;
        private ItemSpriteFactory spriteFactory;
        private int itemIndex = 0;
        private int itemCount;
        private ItemSelect itemSelect;
        private float timer = 0f;
        private int interval = 50;
        private int itemSpeed = 3;
        private bool moveRight = true;

        public Item(Sprint0 game)
        {
            myGame = game;
            position = new Vector2(100, 100);
            spriteFactory = new ItemSpriteFactory(game.Content, game.myGameTime);
            spriteFactory.RegisterSprite();
            itemCount += spriteFactory.itemAndRectangle.Count;
            itemCount += spriteFactory.itemAndFrames.Count;
            aniSprite = new AniItemSprite(spriteFactory, "Star");
            nonAniSprite = new NonAniItemSprite(spriteFactory, "RedMushroom");

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
                itemIndex = itemCount;
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
            aniSprite.Update(gameTime);
            nonAniSprite.Update(gameTime);
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch(itemIndex)
            {
                case 0:
                case 1:
                case 2:
                    nonAniSprite.Draw(spriteBatch);
                    break;
                case 4:
                    aniSprite.Draw(spriteBatch);
                    break;
                case 5:
                case 6:
                case 7:
                    nonAniSprite.Draw(spriteBatch);
                    break;
                case 8:
                    aniSprite.Draw(spriteBatch);
                    break;
            }
        }
    }
}
