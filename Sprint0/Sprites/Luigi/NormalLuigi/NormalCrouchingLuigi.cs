using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint0.Interfaces;
using Sprint0.Characters;

namespace Sprint0.Sprites
{
    internal class NormalCrouchingLuigi : ISprite
    {
        private Luigi luigi;

        // sprite handling stuff
        public Texture2D Texture;
        public Rectangle[] spriteFrames;
        Rectangle destination;
        float rotation = 0, layer = 0;

        SpriteEffects right;

        public NormalCrouchingLuigi(Luigi luigi)
        {
            this.luigi = luigi;
            spriteFrames = new Rectangle[] { new Rectangle(1, 52, 16, 67)};
            right = SpriteEffects.None;

            // if direction is positive then the sprite will turn right (left by default)
            if (this.luigi.myDirection == 1)
            {
                right = SpriteEffects.FlipHorizontally;
            }



        }
        public void Update()
        {
          // nothing needed
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            Texture = Content.Load<Texture2D>("SpriteImages/playerssclear");

            destination = new Rectangle((int)luigi.position.X, (int)luigi.position.Y, 16, 67);

            spriteBatch.Draw(Texture, destination, spriteFrames[0], Color.White, rotation, new Vector2(0, 0), right, layer);
        }

    }
}
