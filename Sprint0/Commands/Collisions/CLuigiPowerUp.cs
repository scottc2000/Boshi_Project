using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Items;

namespace Sprint0.Commands.Collisions
{
    public class CLuigiPowerUp : ICommand
    {
        private Sprint0 sprint;
        private IItem item;
        private ILuigi luigi;
        private GameStats stats;
        public CLuigiPowerUp(Sprint0 sprint, IItem item)
        {
            this.sprint = sprint;
            luigi = this.sprint.levelLoader.luigi;
            stats = this.sprint.stats;
            this.item = item;
        }
        public void Execute()
        {
            ICommand command = new CRemoveDynamic(item, sprint.objects);
            if (item is RedMushroom && luigi.health == Characters.Luigi.LuigiHealth.Normal )
            {
                luigi.ChangeToBig();
            }
            else if (item is Leaf)
            {
                luigi.ChangeToRaccoon();
            }
            else if (item is FireFlower)
            {
                luigi.ChangeToFire();
            }
            else if (item is OneUpMushroom)
            {
                stats.IncrementLives();
            }
            command.Execute();
        }
    }
}
