using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Commands.Collisions
{
    public class CItemDisappear : ICommand
    {
        private Sprint0 sprint;
        private IItem item;
        private GameStats stats;
        private HudNumbers numbers;

        public CItemDisappear(Sprint0 sprint, IItem item)
        {
            this.sprint = sprint;
            this.item = item;
            stats = sprint.hud;
            numbers = new HudNumbers();
        }
        public void Execute()
        {
            stats.IncreaseScore(numbers.itemPoints);
            // remove item sprite
        }
    }
}
