using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sprint0.Sprites.Item_Sprites
{
    internal class OneUpMushroom : ISprite
    {
        private Sprint0 mySprint0 { get; set; }
        private Texture2D greenMushroom;
        private Vector2 destination;
        private int itemSpeed = 3;

        private bool moveRight = true;

        private float timer = 0f;
        private int interval = 50;

        public OneUpMushroom(Sprint0 sprint0)
        {
            mySprint0 = sprint0;
            destination = new Vector2(100, 100);
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval && moveRight)
            {
                destination.X += itemSpeed;
                timer = 0;
                if (destination.X >= 800 - 16) moveRight = false;
            }
            else if (timer > interval && !moveRight)
            {
                destination.X -= itemSpeed;
                timer = 0;
                if (destination.X <= 0) moveRight = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //greenMushroom = content.Load<Texture2D>("NES - Super Mario Bros 3 - Level Items Magic Wands and NPCs");

            //spriteBatch.Draw(greenMushroom, destination, new Rectangle(19, 24, 16, 16), Color.White);

        }
    }
}