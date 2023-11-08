using Sprint0.Interfaces;
using Sprint0.Items;

namespace Sprint0.Commands.Collisions
{
    public class CMarioPowerUp : ICommand
    {
        private Sprint0 sprint;
        private IItem item;
        private IMario mario;
        public CMarioPowerUp(Sprint0 sprint, IItem item)
        {
            this.sprint = sprint;
            mario = this.sprint.objects.mario;
            this.item = item;
        }
        public void Execute()
        {
            System.Diagnostics.Debug.WriteLine("Item: " + item);

            if (item is RedMushroom)
                mario.ChangeToBig();
            else if (item is Leaf)
                mario.ChangeToRaccoon();
            else if (item is FireFlower)
                mario.ChangeToFire();
            else if (item is OneUpMushroom) ;
                // increase HUD life counter
        }
    }
}
