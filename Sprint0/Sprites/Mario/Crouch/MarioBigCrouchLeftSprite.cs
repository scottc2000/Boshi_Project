using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace Sprint0.Sprites
{
    internal class MarioBigCrouchLeftSprite : ISprite
    {
        private Sprint0 mySprint0;
        private Texture2D crouchingMario;

        // Keyboard States
        private KeyboardState current;

        // Rectangles
        private Rectangle spriteFrames;
        private Rectangle position;

        public MarioBigCrouchLeftSprite(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
            spriteFrames = new Rectangle(54, 92, 17, 28);
            position = new Rectangle(150, 150, 34, 56);

        }
        public void Update()
        {
            //Not needed - single file
        }

        public void Draw(SpriteBatch spriteBatch, ContentManager Content)
        {
            crouchingMario = Content.Load<Texture2D>("SpriteImages/playerssclear");

            spriteBatch.Draw(crouchingMario, position, spriteFrames, Color.White);
        }

    }
}
