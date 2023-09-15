using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    internal class Exit : ICommand
    {
        private Sprint0 mySprint0;
        public Exit(Sprint0 game) { 
            mySprint0 = game;
        }
        public void Execute() 
        {
            mySprint0.Exit();
        }

    }
}
