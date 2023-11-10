using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

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
        private float frameInterval;

        public AnimatedBlockSprite(Texture2D textures, Rectangle[] sprite, Vector2 position)
        {
            this.textures = textures;
            scaledPosition = new Rectangle((int)position.X, (int)position.Y, 16, 16);

            frames = sprite;
            currentFrame = 0;
            totalFrames = sprite.Length;
            frameInterval = 0.1f;

        }

        public void Update(GameTime gameTime)
        {
            frameTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (frameTimer >= frameInterval)
            {
                currentFrame = (currentFrame + 1) % totalFrames;
                frameTimer = 0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(textures, scaledPosition, frames[currentFrame], Color.White);
        }

    }
}