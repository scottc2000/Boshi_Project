using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Input;
using System.Timers;

namespace Sprint0.Sprites
{
    internal class MarioJumpSprite : ISprite
    {
        private Sprint0 mySprint0;
        private Texture2D jumpMario;

        private int CurrentFrame = 0;

        // Rectangle stats
        private Rectangle[] spriteFrames;
        private Rectangle destination;

        // Jump Physics
        private Vector2 position;
        private Vector2 velocity;

        public MarioJumpSprite(Sprint0 mySprint0, Rectangle[] frames)
        {
            spriteFrames = frames;
            position.Y = 150;
            position.X = 150;
        }
        public void Update()
        {

            if (position.Y <= 150 && position.Y != 100)
            {
                CurrentFrame = 0;
                position.Y -= 1;
            } else if (position.Y == 100)
            {
                CurrentFrame = 1;
                position.Y += 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            destination = new Rectangle((int)position.X, (int)position.Y, 34, 56);
            jumpMario = Content.Load<Texture2D>("SpriteImages/playerssclear");

            spriteBatch.Draw(jumpMario, destination, spriteFrames[CurrentFrame], Color.White);
        }

    }
}
