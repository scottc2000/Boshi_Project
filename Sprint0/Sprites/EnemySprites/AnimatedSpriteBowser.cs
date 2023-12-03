using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Utility;

namespace Sprint0.Sprites.Players
{
    public class AnimatedSpriteBowser
    {
        private Texture2D texture;

        // Rectangles
        private Rectangle[] spriteFrames;
        public Rectangle destination;
        public string spriteName;

        private SpriteNumbers spriteNumbers = new SpriteNumbers();

        SpriteEffects spriteEffect;

        // Frame stats
        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;

        public AnimatedSpriteBowser(Rectangle[] currentFrames, Texture2D texture, SpriteEffects effect, string name)
        {
            spriteFrames = currentFrames;
            this.texture = texture;
            spriteEffect = effect;
            spriteName = name;
            TotalFrames = spriteFrames.Length;

        }

        public void Update(GameTime gameTime)
        {
            // changes spriteframe every 100 milliseconds
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            //System.Diagnostics.Debug.WriteLine("changing spriteframe");
            if (timeSinceLastFrame > spriteNumbers.millisecondsPerFrame)
            {
                timeSinceLastFrame -= spriteNumbers.millisecondsPerFrame;
                CurrentFrame++;
                System.Diagnostics.Debug.WriteLine(CurrentFrame);
                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destination = new Rectangle((int)location.X, (int)location.Y, spriteFrames[CurrentFrame].Width, spriteFrames[CurrentFrame].Height);

            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(texture, destination, spriteFrames[CurrentFrame], Color.White);
        }
    
    }
}
