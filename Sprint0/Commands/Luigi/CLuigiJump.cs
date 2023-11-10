using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Luigi
{
    internal class CLuigiJump : ICommand
    {
        private Sprint0 sprint;
        private ILuigi luigi;
        public CLuigiJump(Sprint0 sprint, LevelLoader1 level)
        {
            this.sprint = sprint;
            luigi = level.luigi;
        }
        public void Execute()
        { 
  
            luigi.Jump();
            

        }

    }
}