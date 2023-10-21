using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Sprint0.Items;

namespace Sprint0.Commands
{
    internal class previousItem : ICommand
    {
        Item item;

        public previousItem(Item item)
        {
            this.item = item;
        }

        public void Execute()
        {
            //item.decrementItem();
        }
    }
}