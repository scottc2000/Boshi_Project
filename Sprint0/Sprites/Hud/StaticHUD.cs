using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites.Hud
{
    public class StaticHUD : ISprite
    {
        private Vector2 position;
        private Texture2D texture;

        private Rectangle source;
        private Rectangle destination;

        public StaticHUD(Texture2D sheet, Vector2 position)
        {
            texture = sheet;
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            
        }

        public void Update(GameTime gametime)
        {
            // determine if update method is needed as code is built
        }
    }
}
