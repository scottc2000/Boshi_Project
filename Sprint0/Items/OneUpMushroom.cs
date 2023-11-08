using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.Items
{
    internal class OneUpMushroom : IItem
    {
        private AniItemSprite aniItem;
        private Vector2 position;
        public Rectangle itemRectangle { get; set; }

        private int itemSpeed = 1;

        public bool moveRight = false;

        private float timer = 0f;
        private int interval = 15;

        public OneUpMushroom()
        {
            aniItem = ItemSpriteFactory.Instance.returnSprite("OneUpMushroom");
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
            itemRectangle = aniItem.itemPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aniItem.Draw(spriteBatch, position);
        }
    }
}