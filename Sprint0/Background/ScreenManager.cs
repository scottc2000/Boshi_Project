using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Background
{
    public class ScreenManager
    {

        public IScreen state;

        public ScreenManager (Sprint0 sprint)
        {
            state = new HomeScreen(sprint, this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch);
        }

        public void Death()
        {
            state.Death();
        }

        public void Home()
        {
            state.Home();
        }

        public void Level1()
        {
            state.Level1();
        }

    }
}
