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
    internal class CMarioCrouch : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter marioState;
        public CMarioCrouch(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            marioState = mySprint0.marioState;
            marioState.Crouch();
            mySprint0.marioSprite = new CrouchingMario(mySprint0);
        }

    }
}
