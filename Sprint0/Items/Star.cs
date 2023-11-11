using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.ItemSprites;
using Sprint0.Sprites.SpriteFactories;
using System.Collections.Generic;

namespace Sprint0.Items
{
    internal class Star : IItem
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

        //Physics


        //Sprite frames and Location on screen
        private int itemSpeed = 1;

        //Duration of frame
        private float timer = 0;
        private int interval = 15;

        public Star()
        {
            aniItem = ItemSpriteFactory.Instance.returnSprite("Star");
            Destination = aniItem.itemPosition;
            moveRight = true;
        }

        public void setPosition(List<int> pos)
        {
            position.X = pos[0];
            position.Y = pos[1];
        }

        public void Update(GameTime time)
        {
            aniItem.Update(time);
            timer += (float)time.ElapsedGameTime.TotalMilliseconds;
            if (timer > interval && moveRight)
            {
                position.X += itemSpeed;
                timer = 0;
            }
            else if (timer > interval && !moveRight)
            {
                position.X -= itemSpeed;
                timer = 0;
            }
            Destination = aniItem.itemPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aniItem.Draw(spriteBatch, position);
        }
    }
}