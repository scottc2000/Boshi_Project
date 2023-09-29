using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface ICharacter
    {
        public void ChangeDirection();

        public void MoveRight();

        public void MoveLeft();

        public void Jump();

        public void Crouch();

        public void Stop();

        void Draw(SpriteBatch spritebatch, ContentManager content);

    }
}
