using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.Characters.Mario;

<<<<<<< HEAD:Sprint0/Commands/Mario/CMarioNormal.cs
namespace Sprint0.Commands.Mario
{
    internal class CMarioNormal : ICommand
=======
namespace Sprint0.Commands
{

    internal class LuigiCrouch : ICommand
>>>>>>> f36c50eea6a6522d1878aedc5ed220b24a0ee4a3:Sprint0/Commands/Luigi/LuigiCrouch.cs
    {
        private Sprint0 mySprint0;
        private ICharacter mario;
        public CMarioNormal(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mario = mySprint0.mario;
            mario.ChangeToNormal();
        }

    }
}
