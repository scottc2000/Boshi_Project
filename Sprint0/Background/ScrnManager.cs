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
    public class ScrnManager
    {

        public IScreen state;
        private SpriteBatch sprites;

        public ScrnManager(Sprint0 sprint, SpriteBatch spriteBatch)
        {
            state = new HomeScreen(sprint, this);
            sprites = spriteBatch;
        }

        public void Death()
        {
            state.Death();
            state.Draw(sprites);
        }

        public void Draw()
        {
            state.Draw(sprites);
        }

        public void Home()
        {
            state.Home();
            state.Draw(sprites);
        }

        public void Level1()
        {
            state.Level1();
            state.Draw(sprites);
        }
    }
}
