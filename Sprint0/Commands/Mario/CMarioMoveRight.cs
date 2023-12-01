using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Commands
{
    public class CMarioMoveRight : ICommand
    {
       
        private Sprint0 sprint;
        private IMario mario;
        private GameStats hud;
        private HudNumbers numbers;

        public CMarioMoveRight(Sprint0 sprint, LevelLoader1 level, GameStats hud)
        {
            this.sprint = sprint;
            mario = level.mario;
            this.hud = hud;
            numbers = new HudNumbers();
        }
        public void Execute()
        {
            // set mario's direction
            mario.facingLeft = false;

            // if mario has raccoon power, start running timer, else reset
            if (mario.health == Characters.Mario.MarioHealth.Raccoon && mario.pose == Characters.Mario.MarioPose.Walking)
            {
                mario.runningTimer++;
                SetPower();
            }
            else
            {
                mario.runningTimer = 0;
                SetPower();
            }

            // call mario's move method
            mario.Move();
        }

        public void SetPower()
        {
            if (mario.runningTimer == 0)
                hud.PowerLevel(numbers.level0);
            else if (mario.runningTimer < 25)
                hud.PowerLevel(numbers.level1);
            else if (mario.runningTimer > 25 && mario.runningTimer < 50)
                hud.PowerLevel(numbers.level2);
            else if (mario.runningTimer > 50)
                hud.PowerLevel(numbers.level3);
        }

    }
}
