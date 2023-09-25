using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Blocks
{
    internal class BlockNext : ICommand
    {
        private Sprint0 game;
        public BlockNext(Sprint0 game) 
        {
            this.game = game;
        }

        public void Execute() 
        {
            
        }
    }
}
