using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{
    public class CMarioCrouch : ICommand
    {
        private Sprint0 sprint;
        private IMario mario;
        private LevelLoader1 level;
        public CMarioCrouch(Sprint0 sprint, LevelLoader1 level)
        {
            this.sprint = sprint;
            this.level = level;
        }
        public void Execute()
        {
            mario = level.mario;
            mario.Crouch();

        }

    }
}
