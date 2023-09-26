using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites.Item_Sprites
{
    internal class RedMushroom : ISprite
    {
        private Sprint0 mySprint0 { get; set; }
        private Texture2D redMushroom;
        private Vector2 destination;
        private int itemSpeed = 3;

        private bool moveRight = true;

        private float timer = 0f;
        private int interval = 50;

        public RedMushroom(Sprint0 sprint0)
        {
            mySprint0 = sprint0;
            destination = new Vector2(100, 100);
        }

        public void Update()
        {
            timer += (float)mySprint0.myGameTime.ElapsedGameTime.TotalMilliseconds / 2;
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
        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {
            redMushroom = content.Load<Texture2D>("NES - Super Mario Bros 3 - Level Items Magic Wands and NPCs");

            spriteBatch.Draw(redMushroom, destination, new Rectangle(1, 24, 16, 16), Color.White);

        }
    }
}
