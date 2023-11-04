using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{
    internal class CDeadMario : ICommand
    {
        private Sprint0 mysprint;
        private IMario mario;

        public CDeadMario(Sprint0 mysprint)
        {
            this.mysprint = mysprint;
        }

        public void Execute()
        {
            mario = mysprint.objects.mario;
            mario.Die();
        }
    }
}
