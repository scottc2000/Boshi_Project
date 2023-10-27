using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.Items
{
    internal class Star : IItem
    {
        private AniItemSprite aniItem;
        private Vector2 position;
        public Rectangle itemRectangle { get; set; }

        public bool moveRight = true;

        //Physics


        //Sprite frames and Location on screen
        private int itemSpeed = 1;

        //Duration of frame
        private float timer = 0;
        private int interval = 15;

        public Star()
        {
            aniItem = ItemSpriteFactory.Instance.returnSprite("Star");
            itemRectangle = aniItem.itemPosition;
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

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            aniItem.Draw(spriteBatch, position);
        }
    }
}