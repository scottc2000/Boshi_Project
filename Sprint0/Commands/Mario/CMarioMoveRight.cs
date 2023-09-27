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
<<<<<<<< HEAD:Sprint0/Commands/Mario/MarioMoveRightCommand.cs
    internal class MarioMoveRightCommand : ICommand
    {
        private Sprint0 mySprint0;
        public MarioMoveRightCommand(Sprint0 Sprint0)
========
    internal class CMarioMoveRight : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter marioState;
        public CMarioMoveRight(Sprint0 Sprint0)
>>>>>>>> 67867ebcd00e1da7b685c5f2cf443c0b654f2f63:Sprint0/Commands/Mario/CMarioMoveRight.cs
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
<<<<<<<< HEAD:Sprint0/Commands/Mario/MarioMoveRightCommand.cs
            mySprint0.marioSprite = new MarioMoveRightSprite(mySprint0);
========
            marioState = mySprint0.marioState;
            marioState.MoveRight();
            mySprint0.marioSprite = new MarioMovingRight(mySprint0);
>>>>>>>> 67867ebcd00e1da7b685c5f2cf443c0b654f2f63:Sprint0/Commands/Mario/CMarioMoveRight.cs
        }
    }
}
