using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CGetCoin : ICommand
    {
        private Sprint0 sprint;

        public CGetCoin(Sprint0 sprint)
        {
            this.sprint = sprint;
        }

        public void Execute() 
        { 
        }
    }
}
