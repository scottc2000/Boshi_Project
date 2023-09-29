using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Mario
{
    public class CReleasedMario : ICommand
    {
        private Sprint0 mySprint;
        private ICharacter mario;

        public CReleasedMario(Sprint0 sprint0) 
        { 
            mySprint = sprint0;

        }

        public void Execute()
        {
            mario = mySprint.mario;
            mario.Stand();
        }

    }
}
