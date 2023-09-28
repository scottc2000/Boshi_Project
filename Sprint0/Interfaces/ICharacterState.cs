using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface ICharacterState
    {
        public void ChangeDirection();

        public void Move();

        public void Stop();

        public void Draw(SpriteBatch spritebatch, Vector2 location);
    }
}
