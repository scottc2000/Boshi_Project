using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class SetStillSpriteCommand : ICommand
    {
        private Sprint0 mySprint0;
        public SetStillSpriteCommand(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mySprint0.luigiSprite = new StillSprite();
        }

    }
}
