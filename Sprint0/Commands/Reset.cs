﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Commands
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
            spriteBatch = new SpriteBatch(mySprint.GraphicsDevice);
            mySprint.objects.Players[0] = new Characters.Mario(mySprint);
            mySprint.objects.Players[1] = new Characters.Luigi(mySprint);

        }

    }
}
