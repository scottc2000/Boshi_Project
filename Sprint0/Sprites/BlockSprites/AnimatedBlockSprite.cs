using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using System.Data;
using System.Net.Mime;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Sprites
{
    internal class AnimatedBlockSprite : ISprite
    {
        private Texture2D textures;
        private Rectangle[] frames;
        private int currentFrame;
        private int totalFrames;
        private float frameTimer;
        private float frameInterval;
        private Vector2 position;

        public AnimatedBlockSprite(SpriteBatch spriteBatch, Texture2D textures, Rectangle[] sprite, Vector2 position)
        {
            this.textures = textures;
            this.position = position;

            frames = sprite;
            currentFrame = 0;
            totalFrames = 4;
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

        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            spriteBatch.Draw(textures, position, frames[currentFrame], Color.White);
        }

    }
}