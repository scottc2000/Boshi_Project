using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{
    internal class CDeadMario : ICommand
    {
        private Sprint0 mysprint;
        private IMario mario;
        private LevelLoader1 level;

        public CDeadMario(Sprint0 mysprint, LevelLoader1 level)
        {
            this.mysprint = mysprint;
            this.level = level;
        }

        public void Execute()
        {
            mario = level.mario;
            mario.Die();
        }
    }
}
