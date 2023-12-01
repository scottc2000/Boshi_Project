using Sprint0.Commands.Mario;
using Sprint0.HUD;
using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Luigi
{
    internal class CLuigiJump : ICommand
    {
        private Sprint0 sprint;
        private ILuigi luigi;
        private LevelLoader1 level;
        private GameStats hud;
        public CLuigiJump(Sprint0 sprint, LevelLoader1 level, GameStats hud)
        {
            this.sprint = sprint;
            this.level = level;
            luigi = level.luigi;
            this.hud = hud;
        }
        public void Execute()
        {

            if (luigi.health == Characters.Luigi.LuigiHealth.Raccoon)
            {
                ICommand flyCommand = new CLuigiFly(sprint, level, hud);
                flyCommand.Execute();
            }
            else
            {
                luigi.Jump();
            }


        }

    }
}