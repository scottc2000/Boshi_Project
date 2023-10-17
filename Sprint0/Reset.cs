using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Characters;
using Sprint0.Interfaces;


namespace Sprint0
{
    internal class Reset : ICommand
    {
        private Sprint0 mySprint;
        private SpriteBatch spriteBatch;
        private GameTime myGameTime;
        private ContentManager myContent;

        public Reset(Sprint0 game, GameTime gameTime, ContentManager content)
        {
            mySprint = game;
            
            myGameTime = gameTime;
            myContent = content;
        }
        public void Execute()
        {
            // Error CS0118 when moving Reset.cs file to Commands folder
            spriteBatch = new SpriteBatch(mySprint.GraphicsDevice);
            mySprint.mario = new Mario(mySprint);
            mySprint.luigi = new Luigi(mySprint);

        }

    }
}
