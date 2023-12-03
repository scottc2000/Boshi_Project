using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Sprites.GameStates
{
    public class DrawFireWorks : ISprite
    {
        private Texture2D texture;
        private Rectangle spriteLocation;
        private Rectangle destination;
        private SpriteNumbers spriteNumbers;
        private string instructions;
        private SpriteFont font;

        public DrawFireWorks(Texture2D texture, SpriteFont font, Rectangle spriteLocation)
        {
            this.texture = texture;
            this.font = font;
            spriteNumbers = new SpriteNumbers();
            this.spriteLocation = spriteLocation;
            instructions = "Hit 0 to Reset";
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Texture2D _blankTexture = new Texture2D(spriteBatch.GraphicsDevice, spriteNumbers.blankTextureWidth, spriteNumbers.blankTextureHeight);
            _blankTexture.SetData(new[] { Color.DarkBlue });

            destination = new Rectangle(0, 0, 800, 500);
            spriteBatch.Draw(_blankTexture, destination, Color.White);

            destination = new Rectangle((int)location.X, (int)location.Y, 200, 200);
            spriteBatch.Draw(texture, destination, spriteLocation, Color.White);
            spriteBatch.DrawString(font, instructions, new Vector2(250, 350), Color.White);
        }
        public void Update(GameTime gameTime)
        {
        }
    }
}
