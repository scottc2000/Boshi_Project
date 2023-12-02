using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Commands.Player
{
    public class CPlayerFly : ICommand
    {
        private IPlayer player;
        private GameStats stats;
        private HudNumbers numbers;

        public CPlayerFly(IPlayer player, GameStats hud)
        {
            this.player = player;
            stats = hud;
            numbers = new HudNumbers();

        }
        public void Execute()
        {
            if (player.boosted)
            {
                stats.PowerLevel(numbers.level4);
                player.Fly();
            }
            else
            {
                player.Jump();
            }

        }
    }
}

