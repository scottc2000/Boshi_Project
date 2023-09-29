using System;
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
    internal class MarioMoveRightSprite : ISprite
    {
        private Sprint0 mySprint;
        private Texture2D marioMovingRight;

        // Frame Stats
        private int CurrentFrame = 0;
        private int TotalFrames = 3;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 150;

        // Rectanlges
        private Rectangle[] spriteFrames;
        private Rectangle destination;

        private Vector2 position;

        public MarioMoveRightSprite(Sprint0 Sprint0)
        {
            mySprint = Sprint0;
            spriteFrames = new Rectangle[] { new Rectangle(1, 15, 17, 17), new Rectangle(19, 15, 17, 17), new Rectangle(36, 15, 17, 17), new Rectangle(19, 15, 17, 17) };
            position.X = 150;
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

            position.X += 1;

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            marioMovingRight = mySprint.Content.Load<Texture2D>("SpriteImages/playerssclear");

            destination = new Rectangle((int)position.X, 150, 20, 28);

            // Overload parameters to flip sprite horizontally
            SpriteEffects right = SpriteEffects.FlipHorizontally;
            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(marioMovingRight, destination, spriteFrames[CurrentFrame], Color.White, rotation, new Vector2(0,0), right, layer);
        }

    }
}
