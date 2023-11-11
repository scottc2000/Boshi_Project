using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Items;

namespace Sprint0.Commands.Collisions
{
    public class CMarioPowerUp : ICommand
    {
        private Sprint0 sprint;
        private IItem item;
        private IMario mario;
        private GameStats stats;
        public CMarioPowerUp(Sprint0 sprint, IItem item)
        {
            this.sprint = sprint;
            mario = this.sprint.levelLoader.mario;
            stats = this.sprint.levelLoader.hud;
            this.item = item;
        }
        public void Execute()
        {
            ICommand command = new CRemoveDynamic(item, sprint.objects);
            if (item is RedMushroom && mario.health == Characters.Mario.MarioHealth.Normal)
                mario.ChangeToBig();
            else if (item is Leaf)
                mario.ChangeToRaccoon();
            else if (item is FireFlower)
                mario.ChangeToFire();
            else if (item is OneUpMushroom)
            {
                stats.IncrementLives();
            }
            command.Execute();
        }
    }
}
