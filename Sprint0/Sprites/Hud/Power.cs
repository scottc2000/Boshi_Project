using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Sprites.Hud
{
    public class Power : ISprite
    {
        private Texture2D texture;
        private Vector2 size;

        private Rectangle[] spriteFrames;
        private Rectangle destination;

        private SpriteNumbers spriteNumbers;

        // Frame stats
        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;

        public Power(Texture2D sheet, Vector2[] position, Vector2 size)
        {
            texture = sheet;
            spriteNumbers = new SpriteNumbers();
            this.size = size;
            TotalFrames = position.Length;
            spriteFrames = new Rectangle[TotalFrames];

            for (int i = 0; i < TotalFrames; i++)
            {
                spriteFrames[i] = new Rectangle((int)position[i].X, (int)position[i].Y, (int)size.X, (int)size.Y);
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destination = new Rectangle((int)location.X, (int)location.Y, (int)size.X * spriteNumbers.HUDDrawMultiplier, (int)size.Y * spriteNumbers.HUDDrawMultiplier);

            spriteBatch.Draw(texture, destination, spriteFrames[CurrentFrame], Color.White);
        }
        public void Update(GameTime gametime)
        {
            // changes spriteframe every 100 milliseconds
            timeSinceLastFrame += gametime.ElapsedGameTime.Milliseconds;

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
    }
}
