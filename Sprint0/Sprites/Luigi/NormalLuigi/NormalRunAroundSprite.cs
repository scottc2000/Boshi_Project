using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Sprint0.Characters;

namespace Sprint0.Sprites
{
    internal class NormalRunAroundSprite : ISprite
    {

        private Luigi luigi;

        // texture handling
        public Texture2D Texture;
        private Rectangle destination;
        SpriteEffects right;

        // current sprite frame handling
        public int CurrentFrame = 0;
        public int TotalFrames = 2;
        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 100;
        public Rectangle[] leftSpriteFrames;
        

        // position handling
        float rotation;
        float layer;
        // private Vector2 position; DEPRECIATED VARIABLE!!!!!
        

        public NormalRunAroundSprite(Luigi luigi)
        {
            this.luigi = luigi;

            // if direction is positive then the sprite will turn right (left by default)
            leftSpriteFrames = new Rectangle[] { new Rectangle(1, 53, 16, 17) , new Rectangle(19, 51, 16, 17) };


            if (this.luigi.myDirection == 1)
            {
                right = SpriteEffects.FlipHorizontally;
            }
            rotation = 0;
            layer = 0;
            // position.Y = 240;
        }


        public void Update()
        {
            timeSinceLastFrame += luigi.mySprint.myGameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                CurrentFrame++;
                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
            }

            luigi.position.X += luigi.myDirection;

        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            Texture = Content.Load<Texture2D>("SpriteImages/playerssclear");

            destination = new Rectangle((int)luigi.position.X, (int)luigi.position.Y + 30, 27, 27);

            spriteBatch.Draw(Texture, destination, leftSpriteFrames[CurrentFrame], Color.White, rotation, new Vector2(0, 0), right, layer);
        }
    }

    }

