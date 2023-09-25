using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;

namespace Sprint0.Sprites.Item_Sprites
{
    internal class FireFlower : ISprite
    {
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, ContentManager content)
        {
            Texture2D fireFlower = content.Load<Texture2D>("NES - Super Mario Bros 3 - Level Items Magic Wands and NPCs");

            spriteBatch.Draw(fireFlower, new Vector2(100, 100), new Rectangle(37, 24, 16, 16), Color.White);

        }
    }
}
