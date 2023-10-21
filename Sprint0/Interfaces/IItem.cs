using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    internal interface IItem
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
