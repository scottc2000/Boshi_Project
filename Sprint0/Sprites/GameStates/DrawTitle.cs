using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Sprites.GameStates
{
    public class DrawTitle : ISprite
    {
        private Texture2D texture;

        // Rectangles
        private Rectangle destination;
        public string spriteName;

        SpriteEffects spriteEffect;

        private SpriteNumbers spriteNumbers = new SpriteNumbers();

        // Frame stats
        public int CurrentFrame = 0;
        public int TotalFrames;
        public int timeSinceLastFrame = 0;

        public DrawTitle(Texture2D texture, Rectangle destination)
        {
            this.texture = texture;
            this.destination = destination;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Draw(texture, destination, Color.White);
        }
    }
}
