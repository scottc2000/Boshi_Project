using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{
    internal class CMarioBig : ICommand
    {
        private Sprint0 mySprint0;
        private IMario mario;
        private LevelLoader1 level;
        public CMarioBig(Sprint0 Sprint0, LevelLoader1 level)
        {
            mySprint0 = Sprint0;
            this.level = level;
        }
        public void Execute()
        {
            mario = level.mario;
            mario.ChangeToBig();

        }

    }
}
