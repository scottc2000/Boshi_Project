using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites.Projectile
{
    public class AnimatedProjectile : ICollidable, ISingleProjectile
    {
        public Vector2 pos;
        bool facingLeft;
        Rectangle[] spriteFrames;
        Texture2D texture;
        int direction;
        SpriteEffects effect;

        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 100;

        public bool lefthit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool righthit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool uphit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool downhit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool gothit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool stuck { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Rectangle Destination { get; set; }

        public AnimatedProjectile(Rectangle[] currentFrames, Texture2D texture, bool facingLeft, Vector2 pos)
        {
            this.pos = pos;
            pos.X += 10;
            this.facingLeft = facingLeft;
            spriteFrames = currentFrames;
            TotalFrames = spriteFrames.Length;

            this.texture = texture;

            if (this.facingLeft)
            {
                direction = -3;
                effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                direction = 3;
                effect = SpriteEffects.None;
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
            Destination = new Rectangle((int)pos.X, (int)pos.Y, spriteFrames[CurrentFrame].Width, spriteFrames[CurrentFrame].Height);
            float rotation = 0;
            float layer = 0;

            spriteBatch.Draw(texture, Destination, spriteFrames[CurrentFrame], Color.White, rotation, new Vector2(0, 0), effect, layer);
        }
    }
}

