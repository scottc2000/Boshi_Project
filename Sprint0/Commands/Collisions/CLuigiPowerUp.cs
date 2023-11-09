using Sprint0.Interfaces;
using Sprint0.Items;

namespace Sprint0.Commands.Collisions
{
    public class CLuigiPowerUp : ICommand
    {
        private Sprint0 sprint;
        private IItem item;
        private Characters.Luigi luigi;
        public CLuigiPowerUp(Sprint0 sprint, IItem item)
        {
            this.sprint = sprint;
            luigi = this.sprint.objects.luigi;
            this.item = item;
        }
        public void Execute()
        {

            if (item is RedMushroom)
                luigi.ChangeToBig();
            else if (item is Leaf)
                luigi.ChangeToRaccoon();
            else if (item is FireFlower)
                luigi.ChangeToFire();
            else if (item is OneUpMushroom) ;
                // increase HUD life counter
        }
    }
}
