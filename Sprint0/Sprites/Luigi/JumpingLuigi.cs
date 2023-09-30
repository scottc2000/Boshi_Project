using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Sprites
{
    internal class JumpingLuigi : ISprite
    {

        private Sprint0 mySprint0;
        public Texture2D Texture;
        public int CurrentFrame = 0;
        public int TotalFrames = 1;
        
        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 100;
        public Rectangle[] spriteFrames;


        public int y = 240;
        Vector2 position;
        Rectangle destination;
        float rotation = 0, layer = 0;
        SpriteEffects right;


        public JumpingLuigi(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
            spriteFrames = new Rectangle[] { new Rectangle(73, 178, 17, 28)};
            position.X = 400;
            position.Y = 240;
            y = 240;
            right = SpriteEffects.None;
        }
        public void Update(GameTime gameTime)
        {

            if (position.Y > (y - 30))
            {
                position.Y--;
            }

        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            Texture = Content.Load<Texture2D>("SpriteImages/playerssclear");


            destination = new Rectangle((int)position.X, (int)position.Y, 34, 56);

            spriteBatch.Draw(Texture, destination, spriteFrames[0], Color.White, rotation, new Vector2(0, 0), right, layer);
        }
    }

    }

