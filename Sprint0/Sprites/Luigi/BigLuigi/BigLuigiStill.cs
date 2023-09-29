using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Sprint0.Characters;

namespace Sprint0.Sprites
{
    internal class BigLuigiStill : ISprite
    {

        // sprite Drawing handling
        public Rectangle[] spriteFrames;
        Rectangle destination;
        float rotation = 0, layer = 0;
        SpriteEffects flip; // flips to right if needed, faces left by default

        // character handling
        Luigi luigi;

        public BigLuigiStill(Luigi luigi)
        {

            // gets direction currently facing and position from luigi character
            flip = SpriteEffects.None;
            this.luigi = luigi;

            if (this.luigi.myDirection == 1)
            {
                // 1 = right, -1 = left
                flip = SpriteEffects.FlipHorizontally;
            }
            
            spriteFrames = new Rectangle[] {new Rectangle(1,179, 17, 28) };
        }
        public void Update()
        {
            //Nothing needed here
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            Texture2D Texture = Content.Load<Texture2D>("SpriteImages/playerssclear");

            destination = new Rectangle((int)luigi.position.X, (int)luigi.position.Y, 34, 56);

            spriteBatch.Draw(Texture, destination, spriteFrames[0], Color.White, rotation, new Vector2(0, 0), flip, layer);

        }
    }
}
