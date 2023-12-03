using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Sprites.GameStates
{
    public class DrawBackground : ISprite
    {
        private Texture2D texture;

        // Rectangles
        private Rectangle destination;
        public string spriteName;

        SpriteEffects spriteEffect;

        private SpriteNumbers spriteNumbers = new SpriteNumbers();

        // Frame stats
        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;

        public DrawBackground(Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            destination = rectangle;
        }

        public void Update(GameTime gameTime)
        {
            // changes spriteframe every 100 milliseconds
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (timeSinceLastFrame > spriteNumbers.millisecondsPerFrame)
            {
                timeSinceLastFrame -= spriteNumbers.millisecondsPerFrame;
                CurrentFrame++;
                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(texture, destination, Color.White);
        }
    }
}
