using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands.Collisions
{
    internal class CItemBlockX : ICommand
    {
        private Sprint0 myGame;
        private IItem item;

        public CItemBlockX(Sprint0 myGame, IItem item)
        {
            this.myGame = myGame;
            this.item = item;
        }

        public void Execute()
        {
            item.moveRight = !item.moveRight;
        }
    }
}
