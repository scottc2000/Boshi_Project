using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites
{
    internal class AniItemSprite : ISprite
    {
        ItemSpriteFactory factory;
        Item item;
        String itemString;

        private float timer = 0;
        private int interval = 50;
        private int currentFrame = 0;
        private int frameCount;

        private int width = 16, height = 16;

        public AniItemSprite(ItemSpriteFactory factory, Item item, String itemString)
        {
            this.factory = factory;
            this.itemString = itemString;
            this.item = item;
            frameCount = factory.itemAndFrames[itemString].Length;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                currentFrame++;
                timer = 0;
                if (currentFrame == frameCount) currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle position = new Rectangle((int)item.position.X, (int)item.position.Y, width, height);
            spriteBatch.Draw(factory.texture, position, factory.itemAndFrames[itemString][currentFrame], Color.White);
        }
    }
}