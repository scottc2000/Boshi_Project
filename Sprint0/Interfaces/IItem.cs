using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint0.Interfaces
{
    public interface IItem : ICollidable
    { 
        void Draw(SpriteBatch spriteBatch);
        void setPosition(List<int> position);
        void Update(GameTime gameTime);
    }
}
