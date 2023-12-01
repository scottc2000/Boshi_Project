using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class Reset : ICommand
    {
        private Sprint0 sprint;
        private SpriteBatch spriteBatch;
        private LevelLoader1 level;

        public Reset(Sprint0 game, LevelLoader1 level)
        {
             sprint = game;
            this.level = level;
        }
        public void Execute()
        {
            spriteBatch = new SpriteBatch(sprint.GraphicsDevice);
            level.mario = new Characters.Mario(sprint);
            level.luigi = new Characters.Luigi(sprint);

        }

    }
}
