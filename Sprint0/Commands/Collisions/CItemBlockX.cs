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
        private IItem item;

        public CItemBlockX(IItem item)
        {
            this.item = item;
        }

        public void Execute()
        {
            item.moveRight = !item.moveRight;
        }
    }
}
