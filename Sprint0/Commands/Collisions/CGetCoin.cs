using Sprint0.Interfaces;
using Sprint0.HUD;
using Sprint0.GameMangager;

namespace Sprint0.Commands.Collisions
{
    public class CGetCoin : ICommand
    {
        private Sprint0 sprint;
        private ObjectManager objectManager;
        private GameStats stats;

        public CGetCoin(Sprint0 sprint)
        {
            this.sprint = sprint;
            objectManager = sprint.objects;
            stats = sprint.stats;
        }
        public void Execute()
        {

        }

        public void Execute(IBlock block)
        {
            stats.IncrementCoin();
            objectManager.RemoveFromList(block);
        }
    }
}
