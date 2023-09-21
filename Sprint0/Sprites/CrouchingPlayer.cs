using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class CrouchingPlayer : ISprite
    {
        private Sprint0 mySprint0;
        public Texture2D Texture;
        public int Rows = 1;
        public int Columns = 5;
        public int CurrentFrame = 0;
        public int TotalFrames = 5;
        public int x = 320, y = 95;
        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 100;

        public CrouchingPlayer(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Update()
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
        }

        public void Draw(SpriteBatch spriteBatch, int width, int height, ContentManager Content)
        {
            Texture = Content.Load<Texture2D>("post-formatting_texture_atlas");

            int frameWidth = Texture.Width / Columns;
            int frameHeight = Texture.Height / Rows;
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);
            Rectangle destinationRectangle = new Rectangle(x, y, 90, 175);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }

    }
}
