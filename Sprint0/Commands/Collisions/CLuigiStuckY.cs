﻿using System;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CLuigiStuckY : ICommand
    {

        private Sprint0 mySprint0;
        private ICharacter luigi;

        public CLuigiStuckY(Sprint0 mySprint0)
        {
            this.mySprint0 = mySprint0;
        }

        public void Execute()
        {

            luigi = mySprint0.objects.luigi;
            luigi.uphit = true;
        }
    }
}

