using Sprint0.Interfaces;
using System;

namespace Sprint0.Commands.Collisions
{
    public class CMarioTakeDamage : ICommand
    {
        private Sprint0 sprint;
        private ICharacter mario;

        public CMarioTakeDamage(Sprint0 sprint)
        {
            this.sprint = sprint;
            mario = this.sprint.objects.mario;
        }

        public void Execute()
        {
            mario.gothit = true;
        }
    }
}
