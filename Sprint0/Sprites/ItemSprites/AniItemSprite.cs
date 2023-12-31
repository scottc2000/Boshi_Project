﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites.SpriteFactories;
using Sprint0.Utility;

namespace Sprint0.Sprites.ItemSprites
{
    internal class AniItemSprite : ISprite
    {
        string itemString;

        private float timer = 0;
        private int currentFrame = 0;
        public Rectangle[] spriteFrames;
        public Rectangle itemPosition;

        private SpriteNumbers spriteNumbers = new SpriteNumbers();

        public AniItemSprite(Rectangle[] currentFrames)
        {
            spriteFrames = currentFrames;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / spriteNumbers.itemUpdateDivider;
            if (timer > spriteNumbers.itemInterval)
            {
                currentFrame++;
                timer = 0;
                if (currentFrame == spriteFrames.Length) currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            itemPosition = new Rectangle((int)location.X, (int)location.Y, spriteFrames[currentFrame].Width, spriteFrames[currentFrame].Height);
            spriteBatch.Draw(ItemSpriteFactory.Instance.texture, itemPosition, spriteFrames[currentFrame], Color.White);
        }
    }
}