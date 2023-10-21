using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Items;
using Sprint0.Sprites.SpriteFactories;

namespace Sprint0.Sprites.ItemSprites
{
    public class AniItemSprite : ISprite
    {
        ItemSpriteFactory factory;
        Item item;
        string itemString;

        private float timer = 0;
        private int interval = 50;
        private int currentFrame = 0;
        public Rectangle[] spriteFrames;

        private int width = 16, height = 16;

        public AniItemSprite(ItemSpriteFactory factory, Item item, string itemString)
        {
            this.factory = factory;
            this.itemString = itemString;
            this.item = item;
            spriteFrames = currentFrames;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                currentFrame++;
                timer = 0;
                if (currentFrame == spriteFrames.Length) currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle position = new Rectangle((int)item.position.X, (int)item.position.Y, width, height);
            spriteBatch.Draw(factory.texture, position, spriteFrames[currentFrame], Color.White);
        }
    }
}