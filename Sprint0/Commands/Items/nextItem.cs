using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Sprint0.Sprites.ItemSprites;

namespace Sprint0.Commands
{
    internal class nextItem : ICommand
    {
        Item item;

        public nextItem(Item item)
        {
            this.item = item;
        }

        public void Execute()
        {
            item.incrementItem();
        }
    }
}