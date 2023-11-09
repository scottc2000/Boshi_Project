using Sprint0.Interfaces;


namespace Sprint0.Commands.Mario
{
    public class CMarioNormal : ICommand
    {
        private Sprint0 sprint;
        private IMario mario;
        public CMarioNormal(Sprint0 sprint, LevelLoader1 level)
        {
            this.sprint = sprint;
            mario = level.mario;
        }
        public void Execute()
        {
            mario.ChangeToNormal();
        }

    }
}
