﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class SetRunAroundSpriteCommand : ICommand
    {
        private Sprint0 mySprint0;
        public SetRunAroundSpriteCommand(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mySprint0.luigiSprite = new RunAroundSprite(mySprint0);
        }

    }
}
