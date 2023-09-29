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
using Sprint0.Characters;

namespace Sprint0.Sprites
{
    internal class BigJumpingLuigi : ISprite
    {

        private Luigi luigi;

        // sprite handling stuff
        public Texture2D Texture;
        public int CurrentFrame = 0;
        public int TotalFrames = 1;
        
        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 100;
        public Rectangle[] spriteFrames;


        Rectangle destination;
        float rotation = 0, layer = 0;
        SpriteEffects right;


        public BigJumpingLuigi(Luigi luigi)
        {
            this.luigi = luigi;
            spriteFrames = new Rectangle[] { new Rectangle(73, 178, 17, 28)};
            right = SpriteEffects.None;
            // if direction is positive then the sprite will turn right (left by default)
            if (this.luigi.myDirection == 1)
            {
                right = SpriteEffects.FlipHorizontally;
            }
        }
        public void Update()
        {
                // changes position by making the sprite go to the direction of luigi and up
                luigi.position.Y--;
                luigi.position.X += luigi.myDirection;
            

        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            Texture = Content.Load<Texture2D>("SpriteImages/playerssclear");


            destination = new Rectangle((int)luigi.position.X, (int)luigi.position.Y, 34, 56);

            spriteBatch.Draw(Texture, destination, spriteFrames[0], Color.White, rotation, new Vector2(0, 0), right, layer);
        }
    }

    }

