﻿using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    internal class CMarioMoveRight : ICommand
    {
       
        private Sprint0 mySprint0;
        private ICharacter mario;

        public CMarioMoveRight(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mario = mySprint0.mario;
            mario.facingLeft = false;
            mario.Move();
        }
    }
}