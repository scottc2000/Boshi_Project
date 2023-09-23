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
    internal class Frog : ISprite
    {
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {
            Texture2D frog = content.Load<Texture2D>("NES - Super Mario Bros 3 - Level Items Magic Wands and NPCs");

            spriteBatch.Draw(frog, new Vector2(100, 100), new Rectangle(1, 42, 16, 16), Color.White);

        }
    }
}
