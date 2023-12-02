using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class Reset : ICommand
    {
        private Sprint0 sprint;
        private SpriteBatch spriteBatch;
        private LevelLoader1 level;

        public Reset(Sprint0 game)
        {
             sprint = game;
        }
        public void Execute()
        {
            spriteBatch = new SpriteBatch(sprint.GraphicsDevice);

        }
    }
}
