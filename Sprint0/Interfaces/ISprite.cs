using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    public interface ISprite
    {
        void Update(GameTime gametime);
        void Draw(SpriteBatch spriteBatch);

    }
}
