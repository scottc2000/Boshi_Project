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
        private Sprint0 mySprint;
        private Texture2D crouchingMario;

        // Keyboard States
        private KeyboardState current;

        // Rectangles
        private Rectangle spriteFrames;
        private Rectangle position;

        public MarioBigCrouchLeftSprite(Sprint0 Sprint0)
        {
            mySprint = Sprint0;
            spriteFrames = new Rectangle(54, 92, 17, 28);

        }
        public void Update()
        {
            //Not needed - single file
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            crouchingMario = mySprint.Content.Load<Texture2D>("SpriteImages/playerssclear");

            position = new Rectangle((int)location.X, (int)location.Y, 34, 56);

            spriteBatch.Draw(crouchingMario, position, spriteFrames, Color.White);
        }

    }
}
