using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Interfaces
{
    public interface IGameObject
    {   
        void Update(GameTime gameTime, CollisionHandler collision);
        void Draw(SpriteBatch spriteBatch);
    }
}
