using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{ 
    internal class MarioFaceRight : ICommand
    {
        private Sprint0 mySprint0;
        public MarioFaceRight(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mySprint0.marioSprite = new MarioRightFace(mySprint0);
        }
    }
}
