﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class MarioMoveRightSprite : ISprite
    {
        private Sprint0 mySprint;
        private Mario mario;

        // Frame Stats
        private int CurrentFrame = 0;
        private int TotalFrames = 3;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 150;

        // Rectanlges
        private Rectangle[] spriteFrames;
        private Rectangle destination;

        public MarioMoveRightSprite(Sprint0 Sprint0, Mario mario)
        {
            mySprint = Sprint0;
            spriteFrames = new Rectangle[] { new Rectangle(1, 15, 17, 17), new Rectangle(19, 15, 17, 17), new Rectangle(36, 15, 17, 17), new Rectangle(19, 15, 17, 17) };
            this.mario = mario;
        }
        public void Update()
        {

            timeSinceLastFrame += mySprint.myGameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                CurrentFrame++;
                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            destination = new Rectangle((int)mario.position.X, (int)mario.position.Y, 20, 28);

            // Overload parameters to flip sprite horizontally
            SpriteEffects right = SpriteEffects.FlipHorizontally;
            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(mario.marioTexture, destination, spriteFrames[CurrentFrame], Color.White, rotation, new Vector2(0,0), right, layer);
        }

    }
}
