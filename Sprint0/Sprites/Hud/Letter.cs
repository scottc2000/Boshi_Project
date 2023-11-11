using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Sprites.Hud
{
    public class Letter : ISprite
    {
        private Texture2D texture;
        private Vector2 size;

        private Rectangle spriteFrame;
        private Rectangle destination;

        private SpriteNumbers spriteNumbers;

        public Letter(Texture2D sheet, Vector2 position, Vector2 size)
        {
            texture = sheet;
            spriteNumbers = new SpriteNumbers();
            this.size = size;
            spriteFrame = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            destination = new Rectangle((int)location.X, (int)location.Y, (int)size.X * spriteNumbers.HUDDrawMultiplier, (int)size.Y * spriteNumbers.HUDDrawMultiplier);

            spriteBatch.Draw(texture, destination, spriteFrame, Color.White);
        }
        public void Update(GameTime gametime)
        {
            
        }
    }
}
