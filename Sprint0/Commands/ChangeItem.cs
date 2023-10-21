using Sprint0.Interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Commands
{
    internal class ChangeItem
    {
        private Item item;
        private ItemSpriteFactory spriteFactory;

        public ChangeItem(Item item)
        {
            this.item = item;
        }

        public void Update()
        {
            
        }
    }
}
