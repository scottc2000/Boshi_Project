using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Sprites.Hud
{
    public class StaticHUD : ISprite
    {
        private Texture2D texture;
        private Vector2 size;

        private Rectangle spriteFrame;
        private Rectangle destination;
        private Rectangle background;

        private SpriteNumbers spriteNumbers;

        public StaticHUD(Texture2D sheet, Vector2 position, Vector2 size)
        {
            texture = sheet;
            spriteNumbers = new SpriteNumbers();
            this.size = size;
            spriteFrame = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            background = new Rectangle((int)position.X, (int)position.Y, (int)size.X * 4, (int)size.Y * 4);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destination = new Rectangle((int)location.X, (int)location.Y, (int)size.X * spriteNumbers.HUDDrawMultiplier, (int)size.Y * spriteNumbers.HUDDrawMultiplier);

            Texture2D _blankTexture = new Texture2D(spriteBatch.GraphicsDevice, spriteNumbers.blankTextureWidth, spriteNumbers.blankTextureHeight);
            _blankTexture.SetData(new[] { Color.Black });

            spriteBatch.Draw(_blankTexture, new Vector2(location.X - 10, location.Y - 10), background, Color.White);
            spriteBatch.Draw(texture, destination, spriteFrame, Color.White);
        }
        public void Update(GameTime gametime)
        {
            
        }
    }
}
