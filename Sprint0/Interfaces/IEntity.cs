using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface IEntity
    {
        public Rectangle destination { get; set; }
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
