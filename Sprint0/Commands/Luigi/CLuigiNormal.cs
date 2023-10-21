using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sprint0.Characters.Mario;


namespace Sprint0.Commands.Mario
{
    internal class CLuigiNormal : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter luigi;
        public CLuigiNormal(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            luigi = mySprint0.objects.Players[1];
            luigi.ChangeToNormal();
        }

    }
}
