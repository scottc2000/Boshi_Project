using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites.BlockSprites
{
    public class NonAnimatedBlockSprite : ISprite
    {
        private Texture2D textures;
        private Rectangle scaledPosition;
        private Rectangle sprite;
        public NonAnimatedBlockSprite(Texture2D textures, Rectangle sprite, Vector2 position)
        {
            this.textures = textures;
            scaledPosition = new Rectangle((int)position.X, (int)position.Y, 16, 16);
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(textures, scaledPosition, sprite, Color.White);
        }
    }
}
