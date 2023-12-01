using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Utility;
using System.Reflection.Emit;

namespace Sprint0.Commands.Luigi
{
    internal class CLuigiMoveRight : ICommand
    {
       
        private Sprint0 sprint;
        private ILuigi luigi;
        private GameStats hud;
        private HudNumbers numbers;

        public CLuigiMoveRight(Sprint0 sprint, LevelLoader1 level, GameStats hud)
        {
            this.sprint = sprint;
            luigi = level.luigi;
            this.hud = hud;
            numbers = new HudNumbers();
        }
        public void Execute()
        {
            luigi.facingLeft = false;
            if (luigi.health == Characters.Luigi.LuigiHealth.Raccoon && luigi.pose == Characters.Luigi.LuigiPose.Walking)
            {
                luigi.runningTimer++;
                SetPower();
            }
            else
            {
                luigi.runningTimer = 0;
                SetPower();
            }

            luigi.Move();
            
        }

        public void SetPower()
        {
            if (luigi.runningTimer == 0)
                hud.PowerLevel(numbers.level0);
            else if (luigi.runningTimer < 25)
                hud.PowerLevel(numbers.level1);
            else if (luigi.runningTimer > 25 && luigi.runningTimer < 50)
                hud.PowerLevel(numbers.level2);
            else if (luigi.runningTimer > 50)
                hud.PowerLevel(numbers.level3);
        }
    }
}

