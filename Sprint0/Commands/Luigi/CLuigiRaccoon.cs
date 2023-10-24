using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.Characters.Mario;

namespace Sprint0.Commands.Luigi
{

    internal class CLuigiRaccoon : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter luigi;
        public CLuigiRaccoon(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            luigi = mySprint0.objects.luigi;
            luigi.ChangeToRaccoon();
        }

    }
}