using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0
{
    internal class Reset : ICommand
    {
        private Sprint0 mySprint0;
        public Reset(Sprint0 game) { 
            mySprint0 = game;
        }
        public void Execute() 
        {
            mySprint0.marioSprite = new MarioStillLeft();
            mySprint0.luigiSprite = new LuigiStill();
        }

    }
}
