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

namespace Sprint0.Sprites
{
    internal class MarioBigLeftIdleSprite : ISprite
    {
        private Sprint0 mySprint;
        private Texture2D stillMario;
        private Rectangle spriteFrame;
        private Vector2 location { get; set; }

        private Rectangle position;
        public MarioBigLeftIdleSprite(Sprint0 sprint0)
        {
            spriteFrame = new Rectangle(1, 92, 17, 28);
            mySprint = sprint0;
        
        }
        public void Update()
        {
            //Nothing needed here
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Texture2D stillMario = mySprint.Content.Load<Texture2D>("SpriteImages/playerssclear");

            position = new Rectangle((int)location.X, (int)location.Y, 34, 56);

            spriteBatch.Draw(stillMario, position, new Rectangle(1, 90, 17, 28), Color.White);

        }
    }
}