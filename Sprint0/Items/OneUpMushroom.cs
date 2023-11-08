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
    internal class OneUpMushroom : IItem, IEntity
    {
        private AniItemSprite aniItem;
        private Vector2 position;
        public Rectangle destination { get; set; }
        public bool moveRight { get; set; }

        private int itemSpeed = 1;

        private float timer = 0f;
        private int interval = 15;

        public OneUpMushroom()
        {
            aniItem = ItemSpriteFactory.Instance.returnSprite("OneUpMushroom");
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
            destination = aniItem.itemPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aniItem.Draw(spriteBatch, position);
        }
    }
}