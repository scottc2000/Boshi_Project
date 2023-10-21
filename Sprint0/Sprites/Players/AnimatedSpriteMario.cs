using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;
using System;

namespace Sprint0.Sprites.Players
{
    public class AnimatedSpriteMario : ISprite
    {
        private Texture2D texture;

        // Rectangles
        private Rectangle[] spriteFrames;
        public Rectangle destination;
        public string spriteName;

        SpriteEffects spriteEffect;

        // Frame stats
        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 100;

        public AnimatedSpriteMario(Rectangle[] currentFrames, Texture2D texture, SpriteEffects effect, string name)
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

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destination = new Rectangle((int)location.X, (int)location.Y, spriteFrames[CurrentFrame].Width * 2, spriteFrames[CurrentFrame].Height * 2);

            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(texture, destination, spriteFrames[CurrentFrame], Color.White, rotation, new Vector2(0, 0), spriteEffect, layer);
        }
    }
}
