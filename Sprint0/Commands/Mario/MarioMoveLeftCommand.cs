using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Mario
{
    internal class MarioMoveLeftCommand : ICommand
    {
        private Sprint0 mySprint0;
        public MarioMoveLeftCommand(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mySprint0.marioSprite = new MarioMoveLeftSprite(mySprint0);
        }

    }
}
