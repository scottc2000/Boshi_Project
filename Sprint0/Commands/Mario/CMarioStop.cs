using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Mario
{
    public class CMarioStop : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter mario;
        public CMarioStop(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mario = mySprint0.mario;
            mario.Stop();
        }
    }
}
