using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace Sprint0.Sprites
{
    internal class MarioJumpLeftSprite : ISprite
    {
        private Sprint0 mySprint0;
        private Texture2D jumpMario;

        private int CurrentFrame = 0;
        private bool hasJumped;

        // Rectangle stats
        private Rectangle[] spriteFrames;
        private Rectangle destination;

        // Jump Physics
        private Vector2 position;
        private Vector2 velocity;

        public MarioJumpLeftSprite(Sprint0 mySprint0)
        {
            spriteFrames = new Rectangle[] { new Rectangle(72, 0, 17, 28), new Rectangle(36, 0, 17, 28) };
            position.Y = 150;
            position.X = 150;
            hasJumped = true;
        }
        public void Update()
        {

            if (position.Y <= 150 && position.Y != 100 && hasJumped)
            {
                CurrentFrame = 0;
                position.Y -= 1;
            } else if (position.Y == 100 || position.Y <= 150)
            {
                CurrentFrame = 1;
                position.Y += 1;
                hasJumped = false;
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
