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
<<<<<<<< HEAD:Sprint0/Commands/Mario/MarioChangeToFireCommand.cs
    internal class MarioChangeToFireCommand : ICommand { 
  
        private Sprint0 mySprint0;
        private Rectangle[] spriteFrames;
        public MarioChangeToFireCommand(Sprint0 Sprint0)
========
    internal class CMarioCrouch : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter marioState;
        public CMarioCrouch(Sprint0 Sprint0)
>>>>>>>> 67867ebcd00e1da7b685c5f2cf443c0b654f2f63:Sprint0/Commands/Mario/CMarioCrouch.cs
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
<<<<<<<< HEAD:Sprint0/Commands/Mario/MarioChangeToFireCommand.cs

            mySprint0.marioSprite = new MarioCrouchSprite(mySprint0);
========
            marioState = mySprint0.marioState;
            marioState.Crouch();
            mySprint0.marioSprite = new CrouchingMario(mySprint0);
>>>>>>>> 67867ebcd00e1da7b685c5f2cf443c0b654f2f63:Sprint0/Commands/Mario/CMarioCrouch.cs
        }

    }
}
