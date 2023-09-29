using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Blocks
{
    internal class DoNothing : ICommand
    {
        private Sprint0 game;
        public DoNothing(Sprint0 game) 
        {
            this.game = game;
        }

        public void Execute()
        {

        }
    }
}
