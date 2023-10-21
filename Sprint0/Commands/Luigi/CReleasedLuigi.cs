using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Mario
{
    public class CReleasedLuigi : ICommand
    {
        private Sprint0 mySprint;
        private ICharacter luigi;

        public CReleasedLuigi(Sprint0 sprint0) 
        { 
            mySprint = sprint0;

        }

        public void Execute()
        {
            luigi = mySprint.objects.Players[1];
            luigi.Stop();
        }

    }
}
