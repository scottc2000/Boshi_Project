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
    public interface ICharacterState
    {
        public void ChangeDirection();

        public void Move();

        public void Stop();

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch, ContentManager content);
    }
}
