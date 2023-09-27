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
<<<<<<<< HEAD:Sprint0/Commands/Mario/MarioMoveLeftCommand.cs
    internal class MarioMoveLeftCommand : ICommand
    {
        private Sprint0 mySprint0;
        public MarioMoveLeftCommand(Sprint0 Sprint0)
========
    internal class CMarioMoveLeft : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter marioState;
        public CMarioMoveLeft(Sprint0 Sprint0)
>>>>>>>> 67867ebcd00e1da7b685c5f2cf443c0b654f2f63:Sprint0/Commands/Mario/CMarioMoveLeft.cs
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
<<<<<<<< HEAD:Sprint0/Commands/Mario/MarioMoveLeftCommand.cs
            mySprint0.marioSprite = new MarioMoveLeftSprite(mySprint0);
========
            marioState = mySprint0.marioState;
            marioState.MoveLeft();
            mySprint0.marioSprite = new MarioMovingLeft(mySprint0);
>>>>>>>> 67867ebcd00e1da7b685c5f2cf443c0b654f2f63:Sprint0/Commands/Mario/CMarioMoveLeft.cs
        }

    }
}
