﻿using Microsoft.Xna.Framework;
using Sprint0.Characters.LuigiStates;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    internal class LuigiLeft : ICommand
    {
        private Sprint0 mySprint0;
        public LuigiLeft(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mySprint0.luigi.luigiState = new LuigiMoveLeft(mySprint0.luigi);
        }

    }
}