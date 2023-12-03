using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Sprites.BlockSprites
{
    public class NonAnimatedBlockSprite : ISprite
    {
        private Texture2D textures;
        private Rectangle scaledPosition;
        private Rectangle sprite;
        private SpriteNumbers spriteNumbers = new SpriteNumbers();

        public NonAnimatedBlockSprite(Texture2D textures, Rectangle sprite, Vector2 position)
        {
            this.textures = textures;
            scaledPosition = new Rectangle((int)position.X, (int)position.Y, spriteNumbers.blockScaledPos, spriteNumbers.blockScaledPos);
            this.sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            scaledPosition.X = (int)location.X;
            scaledPosition.Y = (int)location.Y;
            spriteBatch.Draw(textures, scaledPosition, sprite, Color.White);
        }
    }
}
