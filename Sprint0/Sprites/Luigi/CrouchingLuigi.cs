﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    internal class CrouchingLuigi : ISprite
    {
        private Sprint0 mySprint0;

        
        public Texture2D Texture;
        public Rectangle[] spriteFrames;

        Vector2 position;
        Rectangle destination;
        float rotation = 0, layer = 0;
        SpriteEffects right;

        public CrouchingLuigi(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
            spriteFrames = new Rectangle[] { new Rectangle(55, 180, 17, 28)};
            right = SpriteEffects.None;
            position.X = 400;
            position.Y = 240;


        }
        public void Update()
        {
          
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            Texture = Content.Load<Texture2D>("SpriteImages/playerssclear");

            destination = new Rectangle((int)position.X, (int)position.Y, 34, 56);

            spriteBatch.Draw(Texture, destination, spriteFrames[0], Color.White, rotation, new Vector2(0, 0), right, layer);
        }

    }
}