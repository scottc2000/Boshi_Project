using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint0.Sprites
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

        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 100;

        public AnimatedProjectile(Rectangle[] currentFrames, Texture2D texture, bool facingLeft, Vector2 pos)
        {
            this.pos = pos;
            pos.X += 10;
            this.facingLeft = facingLeft;
            this.spriteFrames = currentFrames;
            TotalFrames = spriteFrames.Length;

            this.texture = texture;

            if (this.facingLeft)
            {
                direction = -3;
                this.effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                direction = 3;
                this.effect = SpriteEffects.None;
            }

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

            pos.X += direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            destination = new Rectangle((int)pos.X, (int)pos.Y, (spriteFrames[CurrentFrame].Width * 2), (spriteFrames[CurrentFrame].Height * 2));
            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(texture, destination, spriteFrames[CurrentFrame], Color.White, rotation, new Vector2(0, 0), effect, layer);
        }
    }
}

