using Sprint0.Interfaces;
using Sprint0.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Xml.Linq;
using MonoGame.Extended.Timers;
using Sprint0.Utility;


namespace Sprint0.Sprites.goombaSprite
{
    public class KoopaMoveSprite : ISprite
    {
        private Koopa koopa;
        private Texture2D texture;

        // Rectangles
        private Rectangle[] spriteFrames;
        public Rectangle destination;

        private Vector2 position;
        public string spriteName;

        private SpriteNumbers spriteNumbers = new SpriteNumbers();

        // Frame stats
        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;

        public KoopaMoveSprite(Rectangle[] currentFrames, Texture2D texture, Koopa koopa, string name)
        {
            spriteFrames = currentFrames;
            this.texture = texture;
            this.koopa = koopa;
            position = koopa.position;
            spriteName = name;
            TotalFrames = spriteFrames.Length; ;
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
            destination = new Rectangle((int)koopa.position.X, (int)koopa.position.Y, spriteFrames[CurrentFrame].Width, spriteFrames[CurrentFrame].Height);

            spriteBatch.Draw(texture, destination, spriteFrames[CurrentFrame], Color.White);
        }
    }
}
