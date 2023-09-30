﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace Sprint0.Sprites
{
    internal class MarioFireMoveLeftSprite : ISprite
    {
        private Sprint0 mySprint0;
        private Texture2D marioMovingLeft;

        // Frame Stats
        private int CurrentFrame = 0;
        private int TotalFrames = 3;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 150;

        // Rectanlges
        private Rectangle[] spriteFrames;
        private Rectangle destination;

        private Vector2 position;
        public MarioFireMoveLeftSprite(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
            spriteFrames = new Rectangle[] { new Rectangle(1, 263, 17, 28), new Rectangle(19, 263, 17, 28), new Rectangle(36, 0, 17, 28), new Rectangle(19, 263, 17, 28) };
            position.X = 150;

        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += mySprint0.myGameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                CurrentFrame++;
                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
            }

            position.X -= 1;


        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            marioMovingLeft = Content.Load<Texture2D>("SpriteImages/playerssclear");

            destination = new Rectangle((int)position.X, 150, 34, 56);

            spriteBatch.Draw(marioMovingLeft, destination, spriteFrames[CurrentFrame], Color.White);
        }
    }
}
