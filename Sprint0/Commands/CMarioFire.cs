﻿using Microsoft.Xna.Framework;
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
<<<<<<<< HEAD:Sprint0/Commands/playerRight.cs
    internal class playerRight : ICommand
    {
        private Sprint0 mySprint0;
        public playerRight(Sprint0 Sprint0)
========
    internal class CMarioFire : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter mario;
        public CMarioFire(Sprint0 Sprint0)
>>>>>>>> Mario---Muskan:Sprint0/Commands/CMarioFire.cs
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
<<<<<<<< HEAD:Sprint0/Commands/playerRight.cs
            //mySprint0.luigiSprite = new StillSprite();
========
<<<<<<< HEAD:Sprint0/Commands/Mario/CMarioFire.cs
            mario = mySprint0.mario;
            mario.ChangeToFire();
=======
            //mySprint0.luigiSprite = new RunAroundSprite(mySprint0, 1);
>>>>>>> f36c50eea6a6522d1878aedc5ed220b24a0ee4a3:Sprint0/Commands/Luigi/LuigiCommandRight.cs
>>>>>>>> Mario---Muskan:Sprint0/Commands/CMarioFire.cs
        }

    }
}