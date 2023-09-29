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
using Sprint0.Characters;

namespace Sprint0.Sprites
{
    internal class MarioMoveLeftSprite : ISprite
    {
        private Sprint0 mySprint;
        private Texture2D marioMovingLeft;
        private Mario mario;

        // Frame Stats
        private int CurrentFrame = 0;
        private int TotalFrames = 3;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 150;

        // Rectanlges
        private Rectangle[] spriteFrames;
        private Rectangle destination;
        private Vector2 position;


        public MarioMoveLeftSprite(Sprint0 Sprint0, Mario mario)
        {
            mySprint = Sprint0;
            spriteFrames = new Rectangle[] { new Rectangle(1, 15, 17, 17), new Rectangle(19, 15, 17, 17), new Rectangle(36, 15, 17, 17), new Rectangle(19, 15, 17, 17) };
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

            mario.position.X += mario.direction;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            marioMovingLeft = mySprint.Content.Load<Texture2D>("SpriteImages/playerssclear");

            destination = new Rectangle((int)position.X, (int)position.X, 20, 28);

            spriteBatch.Draw(marioMovingLeft, destination, spriteFrames[CurrentFrame], Color.White);
        }
    }
}