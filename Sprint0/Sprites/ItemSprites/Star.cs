using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;

namespace Sprint0.Sprites.Item_Sprites
{
    internal class Star : ISprite
    {
        private Texture2D star;

        private bool moveRight = true;

        //Physics


        //Sprite frame numbers
        private int currentFrame = 0;
        private int frameCount = 3;

        //Sprite frames and Location on screen
        private int itemSpeed = 4;
        private Rectangle[] starFrames;
        private Vector2 destination = new Vector2(100, 100);

        //Duration of frame
        private float timer = 0;
        private int interval = 50;

        public void Update(GameTime time)
        {
            timer += (float)time.ElapsedGameTime.TotalMilliseconds / 2;

            if (timer > interval && moveRight)
            {
                currentFrame++;
                destination.X += itemSpeed;
                timer = 0;
                if (currentFrame == frameCount) currentFrame = 0;
                if (destination.X >= 800 - 16) moveRight = false;
            }
            else if (timer > interval && !moveRight)
            {
                currentFrame++;
                destination.X -= itemSpeed;
                timer = 0;
                if (currentFrame == frameCount) currentFrame = 0;
                if (destination.X <= 0) moveRight = true;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(star, destination, starFrames[currentFrame], Color.White);

        }
    }
}