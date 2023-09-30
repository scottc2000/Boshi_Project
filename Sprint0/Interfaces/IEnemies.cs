using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IEnemies
    {
        public void ChangeDirection();

        public void BeStomped();

        public void BeFlipped();

        public void Draw(SpriteBatch spriteBatch);

        public void Move();

        public void Update(GameTime gameTime);
    }
}
