using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites.Hud
{
    public class StaticHUD : ISprite
    {
        private Texture2D texture;
        private Vector2 size;

        private Rectangle spriteFrame;
        private Rectangle destination;

        public StaticHUD(Texture2D sheet, Vector2 position, Vector2 size)
        {
            texture = sheet;
            this.size = size;
            spriteFrame = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destination = new Rectangle((int)location.X, (int)location.Y, (int)size.X * 2, (int)size.Y * 2);

            Rectangle background = new Rectangle(0, 435, 537, 120);
            Texture2D _blankTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            _blankTexture.SetData(new[] { Color.Black });

            spriteBatch.Draw(_blankTexture, background, spriteFrame, Color.White);
            spriteBatch.Draw(texture, destination, spriteFrame, Color.White);
        }
        public void Update(GameTime gametime)
        {
            
        }
    }
}
