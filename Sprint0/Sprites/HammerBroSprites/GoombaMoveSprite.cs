using Sprint0.Interfaces;
using Sprint0.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace Sprint0.Sprites.goombaSprite
{
    internal class GoombaMoveSprite : ISprite
    {
        private Goomba goomba;

        private int currentFrame = 0;
        private int totalFrames = 2;
        private double frameSpeed = 0.2;

        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 100;

        private Rectangle[] spriteFrames;
        private Rectangle destination;

        public GoombaMoveSprite(Goomba goomba) 
        { 
            this.goomba = goomba;
            spriteFrames = new Rectangle[] { new Rectangle (0, 16, 16, 16), new Rectangle (16, 16, 16, 16 ) };
        }

        public void Update(GameTime gametime)
        {
            timeSinceLastFrame += gametime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            destination = new Rectangle((int)goomba.position.X, (int)goomba.position.Y, 16, 16);

            spriteBatch.Draw(goomba.goombaTexture, destination, spriteFrames[currentFrame], Color.White);
        }
    }
}
