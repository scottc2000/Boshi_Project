using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class SetDeadSpriteCommand : ICommand
    {
        private Sprint0 mySprint0;
        public SetDeadSpriteCommand(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mySprint0.luigiSprite = new MovingSprite();
        }

    }
}
