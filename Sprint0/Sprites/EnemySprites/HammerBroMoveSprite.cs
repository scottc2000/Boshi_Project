﻿using Sprint0.Interfaces;
using Sprint0.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Sprint0.Utility;


namespace Sprint0.Sprites.HammerBroSprite
{
    internal class HammerBroMoveSprite : ISprite
    {
        private HammerBro hammerbro;

        //Unused fields and magic numbers, need removed or moved into Utility/SpriteNumbers
        private int currentFrame = 0;
        private int totalFrames = 4;
        private double frameSpeed = 0.2;

        public int timeSinceLastFrame = 0;

        private Rectangle[] spriteFrames;
        private Rectangle destination;

        private SpriteNumbers spriteNumbers = new SpriteNumbers();

        public HammerBroMoveSprite(HammerBro hammerBro) 
        { 
            this.hammerbro = hammerBro;
            spriteFrames = new Rectangle[] { new Rectangle (0, 456, 16, 24), new Rectangle (16, 456, 16, 24 ), new Rectangle (32, 456, 16, 24 ), new Rectangle (48, 456, 16, 24 ) };
        }

        public void Update(GameTime gametime)
        {
            timeSinceLastFrame += gametime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > spriteNumbers.millisecondsPerFrame)
            {
                timeSinceLastFrame -= spriteNumbers.millisecondsPerFrame;
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
        }
    

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destination = new Rectangle((int)hammerbro.position.X, (int)hammerbro.position.Y, 16, 24);

            spriteBatch.Draw(hammerbro.hammerBroTexture, destination, spriteFrames[currentFrame], Color.White);
        }
    }
}
