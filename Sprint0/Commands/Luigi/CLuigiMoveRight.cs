using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    internal class CLuigiMoveRight : ICommand
    {
       
        private Sprint0 mySprint0;
        private ICharacter luigi;

        public CLuigiMoveRight(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            luigi = mySprint0.objects.Players[1];
            luigi.facingLeft = false;
            if (!luigi.lefthit)
            {
                luigi.Move();
            }
        }
    }
    }

