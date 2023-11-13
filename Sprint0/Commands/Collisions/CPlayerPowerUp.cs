using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Items;

namespace Sprint0.Commands.Collisions
{
    public class CPlayerPowerUp : ICommand
    {
        private Sprint0 sprint;
        private IItem item;
        private IPlayer player;
        private GameStats stats;
        public CPlayerPowerUp(Sprint0 sprint, IItem item, IPlayer player)
        {
            this.sprint = sprint;
            this.player = player;
            stats = this.sprint.levelLoader.hud;
            this.item = item;
        }
        public void Execute()
        {
            ICommand command = new CRemoveDynamic(item, sprint.objects);
            if (item is RedMushroom && player.health == Characters.Player.PlayerHealth.Normal)
                player.ChangeToBig();
            else if (item is Leaf)
                player.ChangeToRaccoon();
            else if (item is FireFlower)
                player.ChangeToFire();
            else if (item is OneUpMushroom)
            {
                stats.IncrementLives();
            }
            command.Execute();
        }
    }
}
