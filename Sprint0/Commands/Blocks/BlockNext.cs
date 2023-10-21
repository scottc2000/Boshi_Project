using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0.Blocks;

namespace Sprint0.Commands.Blocks
{
    internal class BlockNext : ICommand
    {
        private Sprint2Block block;
        public BlockNext(Sprint2Block block) 
        {
            this.block = block;
        }

        public void Execute() 
        {
            block.IncrementBlockIndex();

        }
    }
}
