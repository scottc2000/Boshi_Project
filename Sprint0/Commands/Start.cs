using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Background;
using MonoGame.Extended.Screens;

namespace Sprint0.Commands
{
    public class Start : ICommand
    {
        private Sprint0 sprint;
        private SpriteBatch spriteBatch;

        public Start(Sprint0 game)
        {
             sprint = game;
        }
        public void Execute()
        {
            //spriteBatch = new SpriteBatch(sprint.GraphicsDevice);
            sprint.screenManager.currentCamera = ScrnManager.Camera.Player;
            System.Diagnostics.Debug.WriteLine("switch player cam");
        }
    }
}
