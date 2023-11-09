using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface IGameObject
    {   
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
