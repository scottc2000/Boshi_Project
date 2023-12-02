using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Sprites
{
    public class AnimatedBlockSprite : ISprite
    {
        private Texture2D textures;
        private Rectangle[] frames;
        private Rectangle scaledPosition;
        private int currentFrame;
        private int totalFrames;
        private float frameTimer;
        private SpriteNumbers spriteNumbers = new SpriteNumbers();

        public AnimatedBlockSprite(Texture2D textures, Rectangle[] sprite, Vector2 position)
        {
            this.textures = textures;
            scaledPosition = new Rectangle((int)position.X, (int)position.Y, spriteNumbers.blockScaledPos, spriteNumbers.blockScaledPos);

            frames = sprite;
            currentFrame = 0;
            totalFrames = sprite.Length;
        }

        public void Update(GameTime gameTime)
        {
            frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (frameTimer >= spriteNumbers.frameInterval)
            {
                currentFrame = (++currentFrame) % totalFrames;
                frameTimer = 0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            scaledPosition.X = (int)location.X;
            scaledPosition.Y = (int)location.Y;
            spriteBatch.Draw(textures, scaledPosition, frames[currentFrame], Color.White);
        }

    }
}