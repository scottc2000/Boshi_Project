using Sprint0.Interfaces;
using Sprint0.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace Sprint0.Sprites.KoopaSprite
{
    internal class KoopaMoveSprite : ISprite
    {
        private Koopa koopa;

        private int currentFrame = 0;
        private int totalFrames = 2;
        private double frameSpeed = 0.2;

        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 100;

        private Rectangle[] spriteFrames;
        private Rectangle destination;

        public KoopaMoveSprite(Koopa koopa) 
        { 
            this.koopa = koopa;
            spriteFrames = new Rectangle[] { new Rectangle (0, 51, 16, 27), new Rectangle (16, 51, 16, 27 ) };
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

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destination = new Rectangle((int)koopa.position.X, (int)koopa.position.Y, 34, 56);

            spriteBatch.Draw(koopa.koopaTexture, destination, spriteFrames[currentFrame], Color.White);
        }
    }
}
