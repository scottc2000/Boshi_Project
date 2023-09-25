using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    internal class MarioJumpCommand : ICommand
    {
        private Sprint0 mySprint0;
        private Rectangle[] frames;
        public MarioJumpCommand(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
            frames = new Rectangle[] { new Rectangle(72, 92, 17, 28), new Rectangle(36, 92, 17, 28) };
        }
        public void Execute()
        {
            mySprint0.marioSprite = new MarioJumpSprite(mySprint0, frames);
        }

    }
}
