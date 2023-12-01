using Sprint0.Commands.Mario;
using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Luigi
{
    internal class CLuigiJump : ICommand
    {
        private Sprint0 sprint;
        private ILuigi luigi;
        private LevelLoader1 level;
        public CLuigiJump(Sprint0 sprint, LevelLoader1 level)
        {
            this.sprint = sprint;
            this.level = level;
            luigi = level.luigi;
        }
        public void Execute()
        {

            if (luigi.health == Characters.Luigi.LuigiHealth.Raccoon)
            {
                ICommand flyCommand = new CLuigiFly(sprint, level);
                flyCommand.Execute();
            }
            else
            {
                luigi.Jump();
            }


        }

    }
}