using System;
using System.Reflection.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
	public class AnimatedSprite : ISprite
	{
        public Texture2D texture;
        float rotation;
        float layer;
        private Rectangle destination;

        ContentManager content;
        GameTime gameTime;

        Rectangle[] sprites;

        public String spriteName;

        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 100;
        public SpriteEffects flip;




        public AnimatedSprite(Rectangle[] sprites, GameTime gameTime, Texture2D Texture, Rectangle destination)
		{
            this.destination = destination;
            this.sprites = sprites;
            this.TotalFrames = sprites.Length;
            this.gameTime = gameTime;
            this.texture = Texture;
            rotation = 0;
            layer = 0;
            flip = SpriteEffects.None;
            this.spriteName = "X";
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {
            spriteBatch.Draw(texture, destination, sprites[CurrentFrame], Color.White, rotation, new Vector2(0, 0), flip, layer);
        }

        public void Update()
        {
            if (gameTime != null)
            {
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame -= millisecondsPerFrame;
                    CurrentFrame++;
                    if (CurrentFrame == TotalFrames)
                    {
                        CurrentFrame = 0;
                    }
                }
            }
        }
    }
}

