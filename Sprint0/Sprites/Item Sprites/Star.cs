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
        private Sprint0 starSprint0 { get; set; }
        private Texture2D star;

        private bool moveRight = true;

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

        public Star(Sprint0 sprint0)
        {
            starSprint0 = sprint0;
            starFrames = new Rectangle[] {new Rectangle(73, 24, 16, 16), new Rectangle(90, 24, 16, 16), new Rectangle(107, 24, 16, 16), new Rectangle(124, 24, 16, 16) };
            
        }

        public void Update()
        {
            timer += (float)starSprint0.myGameTime.ElapsedGameTime.TotalMilliseconds / 2;

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

        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {
            star = content.Load<Texture2D>("NES - Super Mario Bros 3 - Level Items Magic Wands and NPCs");

            spriteBatch.Draw(star, destination, starFrames[currentFrame], Color.White);

        }
    }
}
