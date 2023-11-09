using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CItemDisappear : ICommand
    {
        private Sprint0 sprint;
        private IItem item;

        public CItemDisappear(Sprint0 sprint, IItem item)
        {
            this.sprint = sprint;
            this.item = item;
        }
        public void Execute()
        {
            // remove item sprite
        }
    }
}
