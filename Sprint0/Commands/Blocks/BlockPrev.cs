using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Sprint0.Sprites;

namespace Sprint0.Commands.Blocks
{
    internal class BlockPrev : ICommand
    {
        private Sprint0 game;
        public BlockPrev(Sprint0 game) 
        {
            this.game = game;
        }

        public void Execute() 
        {
            //game.blockSprite = new BlockSprites();
        }
    }
}
