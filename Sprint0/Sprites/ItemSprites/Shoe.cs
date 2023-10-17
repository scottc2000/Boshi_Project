using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.Item_Sprites
{
    internal class Shoe : ISprite
    {
        private Sprint0 shoeSprint0 { get; set; }
        private Texture2D shoe;

        //Sprite frame numbers
        private int currentFrame = 0;
        private int frameCount = 2;

        //Sprite frames and location on screen
        private Rectangle[] shoeFrames;
        private Vector2 destination = new Vector2(100, 100);

        //Duration of frame
        private float timer = 0;
        private int interval = 50;

        public Shoe(Sprint0 sprint0)
        {
            shoeSprint0 = sprint0;
            shoeFrames = new Rectangle[] { new Rectangle(55, 42, 16, 16), new Rectangle(72, 42, 16, 16) };
        }

        public void Update(GameTime time)
        {
            timer += (float)time.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                currentFrame++;
                timer = 0;
                if (currentFrame == frameCount) currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(shoe, destination, shoeFrames[currentFrame], Color.White);

        }
    }
}