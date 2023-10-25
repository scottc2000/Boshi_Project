using Sprint0.Interfaces;
using System.Collections.Generic;

namespace Sprint0.Commands.Collisions
{
    public class CMarioPowerUp : ICommand
    {
        private Sprint0 sprint;
        private IItem items;
        private ICharacter mario;
        public CMarioPowerUp(Sprint0 sprint, IItem item)
        {
            this.sprint = sprint;
            mario = this.sprint.objects.mario;
            this.items = item;
        }
        public void Execute()
        {
            // filter through each item in items list - Update conditional when completed

            /*if (items == RedMushroom)
            {
                mario.ChangeToBig();
            }*/
        }
    }
}
