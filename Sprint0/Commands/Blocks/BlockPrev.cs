using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Blocks;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Commands.Blocks
{
    internal class BlockPrev : ICommand
    {
        private Sprint2Block block;
        public BlockPrev(Sprint2Block block)
        {
            this.block = block;
        }

        public void Execute()
        {
            block.DecrementBlockIndex();

        }
    }
}
