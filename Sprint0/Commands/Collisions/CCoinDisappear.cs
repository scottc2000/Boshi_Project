using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    internal class CCoinDisappear : ICommand
    {
        private Sprint0 game;
        public CCoinDisappear(Sprint0 game) 
        {
            this.game = game;
        }

        public void Execute()
        {

        }
    }
}
