using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class Reset : ICommand
    {
        private Sprint0 mySprint;
        private SpriteBatch spriteBatch;

        public Reset(Sprint0 game)
        {
            mySprint = game;
        }
        public void Execute()
        {
            spriteBatch = new SpriteBatch(mySprint.GraphicsDevice);
            mySprint.objects.mario = new Characters.Mario(mySprint);
            mySprint.objects.luigi = new Characters.Luigi(mySprint);

        }

    }
}
