using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using Sprint0.GameMangager;

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

