using System;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CLuigiStuckX : ICommand
    {

        private Sprint0 mySprint0;
        private ICharacter luigi;

        public CLuigiStuckX(Sprint0 mySprint0)
        {
            this.mySprint0 = mySprint0;
        }

        public void Execute()
        {

            luigi = mySprint0.objects.Players[1];
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

