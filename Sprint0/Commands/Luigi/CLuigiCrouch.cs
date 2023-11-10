using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Luigi
{
    internal class CLuigiCrouch : ICommand
    {
        private Sprint0 sprint;
        private ILuigi luigi;
        public CLuigiCrouch(Sprint0 sprint, LevelLoader1 level)
        {
            this.sprint = sprint;
            luigi = level.luigi;
        }
        public void Execute()
        {
            luigi.Crouch();

        }

    }
}
