using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Sprites.GameStates
{
    public class DrawGameOver : ISprite
    {
        private Texture2D texture;
        private SpriteFont font;
        private SpriteNumbers spriteNumbers;

        // Rectangles
        private Rectangle destination;

        private string header;
        private string instructions;

        public DrawGameOver(SpriteFont font, string Header, string Instructions)
        {
            spriteNumbers = new SpriteNumbers();
            this.font = font;
            header = Header;
            instructions = Instructions;
            destination = new Rectangle(0, 0, 800, 500);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Texture2D _blankTexture = new Texture2D(spriteBatch.GraphicsDevice, spriteNumbers.blankTextureWidth, spriteNumbers.blankTextureHeight);
            _blankTexture.SetData(new[] { Color.Black });

            spriteBatch.Draw(_blankTexture, destination, Color.White);
            spriteBatch.DrawString(font, header, new Vector2(250, 150), Color.White);
            spriteBatch.DrawString(font, instructions, new Vector2(250, 250), Color.White);
        }
    }
}
