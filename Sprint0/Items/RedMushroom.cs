using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.ItemSprites;
using Sprint0.Sprites.SpriteFactories;
using System.Collections.Generic;

namespace Sprint0.Items
{
    public class RedMushroom : IItem
    {
        private AniItemSprite aniItem;
        private Vector2 position;

        private int itemSpeed = 1;

        public bool moveRight { get; set; }

        private float timer = 0f;
        private int interval = 15;
        public Rectangle Destination { get; set; }
        public bool lefthit { get; set; }
        public bool righthit { get; set; }
        public bool uphit { get; set; }
        public bool downhit { get; set; }
        public bool gothit { get; set; }
        public bool stuck { get; set; }

        public RedMushroom()
        {
            aniItem = ItemSpriteFactory.Instance.returnSprite("RedMushroom");
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
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
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
