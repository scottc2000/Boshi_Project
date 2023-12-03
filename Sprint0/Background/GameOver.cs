using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Sprites.GameStates;
using Sprint0.Utility;

namespace Sprint0.Background
{
    public class GameOver
    {
        private Texture2D title;
        private Sprint0 sprint0;
        private ISprite sprite;
        private Vector2 location;
        private SpriteFont font;
        private FileNames filename;

        public GameOver(Sprint0 sprint0)
        {
            this.sprint0 = sprint0;
            filename = new FileNames();
            font = sprint0.Content.Load<SpriteFont>(filename.font);
            string GameOver = "GAMEOVER";
            string reset = "Press 0 to reset";
            sprite = new DrawGameOver(font, GameOver, reset);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
