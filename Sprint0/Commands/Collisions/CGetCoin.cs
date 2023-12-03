using Sprint0.Interfaces;
using Sprint0.HUD;
using Sprint0.GameMangager;
using Sprint0.Utility;

namespace Sprint0.Commands.Collisions
{
    public class CGetCoin : ICommand
    {
        private Sprint0 sprint;
        private ObjectManager objectManager;
        private GameStats stats;
        private HudNumbers numbers;

        public CGetCoin(Sprint0 sprint)
        {
            this.sprint = sprint;
            numbers = new HudNumbers();
            objectManager = sprint.objects;
            stats = sprint.hud;
        }
        public void Execute()
        {

        }

        public void Execute(IBlock block)
        {
            stats.IncrementCoin();
            stats.IncreaseScore(numbers.coinPoints);
            objectManager.RemoveFromList(block);
        }
        public void Execute(IItem item)
        {
            stats.IncrementCoin();
            objectManager.RemoveFromList(item);
        }
    }
}
