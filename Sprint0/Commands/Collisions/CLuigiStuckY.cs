using System;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CLuigiStuckY : ICommand
    {
        private ICharacter luigi;

        public CLuigiStuckY(ICharacter luigi)
        {
            this.luigi = luigi;
        }

        public void Execute()
        {
            luigi.uphit = true;
        }
    }
}

