using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Luigi
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
            luigi = mySprint0.objects.luigi;
            luigi.facingLeft = false;
            
            luigi.Move();
            
        }
    }
    }

