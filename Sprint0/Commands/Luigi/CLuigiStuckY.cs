using System;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Luigi
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

            luigi = mySprint0.objects.Players[1];
            luigi.lefthit = true;


        }
    }
}

