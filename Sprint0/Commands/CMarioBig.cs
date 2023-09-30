using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.Characters.Mario;

namespace Sprint0.Commands.Mario
{
<<<<<<<< HEAD:Sprint0/Commands/playerLeft.cs
    internal class playerLeft : ICommand
    {
        private Sprint0 mySprint0;
        public playerLeft(Sprint0 Sprint0)
========
    internal class CMarioBig : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter mario;
        public CMarioBig(Sprint0 Sprint0)
>>>>>>>> Mario---Muskan:Sprint0/Commands/CMarioBig.cs
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
<<<<<<<< HEAD:Sprint0/Commands/playerLeft.cs
            //mySprint0.luigiSprite = new RunAroundSprite(mySprint0);
========
<<<<<<< HEAD:Sprint0/Commands/Mario/CMarioBig.cs
            mario = mySprint0.mario;
            mario.ChangeToBig();
=======
            //mySprint0.luigiSprite = new RunAroundSprite(mySprint0, -1);
>>>>>>> f36c50eea6a6522d1878aedc5ed220b24a0ee4a3:Sprint0/Commands/Luigi/LuigiCommandLeft.cs
>>>>>>>> Mario---Muskan:Sprint0/Commands/CMarioBig.cs
        }

    }
}
