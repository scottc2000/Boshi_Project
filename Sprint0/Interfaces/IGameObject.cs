using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Collision;

namespace Sprint0.Interfaces
{
    public interface IGameObject
    {   
        void Update(GameTime gameTime, CollisionHandler collision);
        void Draw(SpriteBatch spriteBatch);
    }
}
