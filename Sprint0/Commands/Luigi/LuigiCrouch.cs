using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:Sprint0/Commands/Mario/MarioFaceRightCommand.cs
namespace Sprint0.Commands
{ 
    internal class MarioFaceRightCommand : ICommand
    {
        private Sprint0 mySprint0;
        public MarioFaceRightCommand(Sprint0 Sprint0)
========
namespace Sprint0.Commands.Luigi
{
    internal class LuigiCrouch : ICommand
    {
        private Sprint0 mySprint0;
        public LuigiCrouch(Sprint0 Sprint0)
>>>>>>>> 67867ebcd00e1da7b685c5f2cf443c0b654f2f63:Sprint0/Commands/Luigi/LuigiCrouch.cs
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
<<<<<<<< HEAD:Sprint0/Commands/Mario/MarioFaceRightCommand.cs
            mySprint0.marioSprite = new MarioFaceRightSprite(mySprint0);
========
            mySprint0.luigiSprite = new CrouchingLuigi(mySprint0);
>>>>>>>> 67867ebcd00e1da7b685c5f2cf443c0b654f2f63:Sprint0/Commands/Luigi/LuigiCrouch.cs
        }

    }
}
