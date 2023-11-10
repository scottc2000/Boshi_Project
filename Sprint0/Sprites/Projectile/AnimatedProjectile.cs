using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Utility;


namespace Sprint0.Sprites.Projectile
{
    public class AnimatedProjectile
    {
        public Vector2 pos;
        bool facingLeft;
        Rectangle[] spriteFrames;
        Texture2D texture;
        int direction;
        Rectangle destination;
        SpriteEffects effect;

        private SpriteNumbers spriteNumbers = new SpriteNumbers();

        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;

        public AnimatedProjectile(Rectangle[] currentFrames, Texture2D texture, bool facingLeft, Vector2 pos)
        {
            this.pos = pos;
            pos.X += spriteNumbers.projectileTravelDif;
            this.facingLeft = facingLeft;
            spriteFrames = currentFrames;
            TotalFrames = spriteFrames.Length;

            this.texture = texture;

            if (this.facingLeft)
            {
                direction = spriteNumbers.projectileLeftOffset;
                effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                direction = spriteNumbers.projectileRightOffset;
                effect = SpriteEffects.None;
            }

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

            pos.X += direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            destination = new Rectangle((int)pos.X, (int)pos.Y, spriteFrames[CurrentFrame].Width * spriteNumbers.projectileDrawMultiplier, spriteFrames[CurrentFrame].Height * spriteNumbers.projectileDrawMultiplier);
            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(texture, destination, spriteFrames[CurrentFrame], Color.White, rotation, new Vector2(0, 0), effect, layer);
        }
    }
}

