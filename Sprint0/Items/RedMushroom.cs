using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Sprites.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;

namespace Sprint0.Items
{
    internal class RedMushroom : IItem
    {
        private AniItemSprite aniItem;
        private Vector2 position;
        public Rectangle itemRectangle { get; set; }

        private int itemSpeed = 1;

        public bool moveRight = false;

        private float timer = 0f;
        private int interval = 15;

        public RedMushroom()
        {
            aniItem = ItemSpriteFactory.Instance.returnSprite("RedMushroom");
            itemRectangle = aniItem.itemPosition;
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aniItem.Draw(spriteBatch, position);
        }
    }
}
