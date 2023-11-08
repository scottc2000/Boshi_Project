﻿using System;
using Sprint0.Characters.MarioStates;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CLuigiStuckX : ICommand
    {
        private ICharacter luigi;

        public CLuigiStuckX(ICharacter luigi)
        {
            this.luigi = luigi;
        }

        public void Execute()
        {
            if (luigi.facingLeft)
            {
                luigi.stuck = true;
                luigi.lefthit = true;
            }
            else
            {
                luigi.stuck = true;
                luigi.righthit = true;
            }

            
        }
    }
}

