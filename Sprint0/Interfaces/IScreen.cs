using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IScreen
    {

        public void Death();
        public void Home();
        public void Level1();

        public void Draw(SpriteBatch spriteBatch);
    }
}
