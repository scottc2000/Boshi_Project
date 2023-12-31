﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies;
using Sprint0.Interfaces;
using Sprint0.Utility;


namespace Sprint0.Sprites.goombaSprite
{
    public class GoombaMoveSprite : ISprite
    {
        private Goomba goomba;
        private Texture2D texture;

        // Rectangles
        private Rectangle[] spriteFrames;
        public Rectangle destination;

        private SpriteNumbers spriteNumbers = new SpriteNumbers();

        private Vector2 position;
        public string spriteName;

        // Frame stats
        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;

        public GoombaMoveSprite(Rectangle[] currentFrames, Texture2D texture, Goomba goomba, string name) 
        {
            spriteFrames = currentFrames;
            this.texture = texture;
            this.goomba = goomba;
            position = goomba.position;
            spriteName = name;
            TotalFrames = spriteFrames.Length;
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
            destination = new Rectangle((int)goomba.position.X, (int)goomba.position.Y, spriteFrames[CurrentFrame].Width, spriteFrames[CurrentFrame].Height);

            spriteBatch.Draw(texture, destination, spriteFrames[CurrentFrame], Color.White);
        }
    }
}
