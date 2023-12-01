using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{
    internal class CMarioThrow : ICommand
    {
        private Sprint0 sprint;
        private IMario mario;
        public CMarioThrow(Sprint0 sprint, LevelLoader1 level)
        {
            this.sprint = sprint;
            mario = level.mario;
        }
        public void Execute()
        {
            mario.Throw();

        }

    }
}
