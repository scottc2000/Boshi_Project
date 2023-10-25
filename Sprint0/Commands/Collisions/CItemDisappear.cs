using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CItemDisappear : ICommand
    {
        private Sprint0 sprint;

        public CItemDisappear(Sprint0 sprint)
        {
            this.sprint = sprint;
        }
        public void Execute()
        {
            // remove item sprite
        }
    }
}
