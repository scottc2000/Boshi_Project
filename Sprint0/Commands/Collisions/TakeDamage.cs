using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class TakeDamage : ICommand
    {
        private Sprint0 sprint;
        private ICharacter mario;
        private ICharacter luigi;

        public TakeDamage(Sprint0 sprint)
        {
            this.sprint = sprint;
        }

        public void Execute()
        {
            if (mario == sprint.objects.Players)
            {
                mario = sprint.objects.Players[0];
                if (mario.facingLeft)
                    mario.lefthit = true;
                else
                    mario.righthit = true;
                mario.TakeDamage();
            }
            else if (luigi == sprint.objects.Players)
            {
                luigi = sprint.objects.Players[1];
                luigi.TakeDamage();
            }
        }
    }
}
