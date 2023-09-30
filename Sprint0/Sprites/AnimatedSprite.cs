using System;
using System.Reflection.Emit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
	public class AnimatedSprite : ISprite
	{
        public Texture2D texture;
        float rotation;
        float layer;
        int[] destination;
        public int direction;

        ContentManager content;
        GameTime gameTime;

        Rectangle[] sprites;

        public String spriteName;

        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;
        public int millisecondsPerFrame = 100;
        public SpriteEffects flip;
        




        public AnimatedSprite(Rectangle[] sprites, GameTime gameTime, Texture2D Texture, int[] destination, int myDirection)
		{
            this.destination = destination;
            this.sprites = sprites;
            this.TotalFrames = sprites.Length;
            this.gameTime = gameTime;
            this.texture = Texture;
            rotation = 0;
            layer = 0;
            flip = SpriteEffects.None;
            direction = myDirection;
            this.spriteName = "X";
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager content, Vector2 pos)
        {
            Rectangle destinationrect = new Rectangle((int)pos.X, (int)pos.Y, destination[0], destination[1]);
            spriteBatch.Draw(texture, destinationrect, sprites[CurrentFrame], Color.White, rotation, new Vector2(0, 0), flip, layer);
        }

        public void Update(GameTime gameTime)
            
        {
            if (direction == 1)
            {
                // 1 = right, -1 = left
                flip = SpriteEffects.FlipHorizontally;

            }
            else
            {
                flip = SpriteEffects.None;
            }


            this.gameTime = gameTime;
            if (this.gameTime != null)
            {
                timeSinceLastFrame += this.gameTime.ElapsedGameTime.Milliseconds;

                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame -= millisecondsPerFrame;
                    CurrentFrame++;
                    if (CurrentFrame == TotalFrames)
                    {
                        CurrentFrame = 0;
                    }
                }
            }
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {
            throw new NotImplementedException();
        }
    }
}

