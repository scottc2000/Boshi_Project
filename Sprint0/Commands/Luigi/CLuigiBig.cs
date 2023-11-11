using Sprint0.Interfaces;

namespace Sprint0.Commands.Luigi
{
    internal class CLuigiBig : ICommand
    {
        private Sprint0 sprint;
        private ILuigi luigi;
        public CLuigiBig(Sprint0 sprint,LevelLoader1 level)
        {
            this.sprint = sprint;
            luigi = level.luigi;
        }
        public void Execute()
        {
            luigi.ChangeToBig();

        }

    }
}
