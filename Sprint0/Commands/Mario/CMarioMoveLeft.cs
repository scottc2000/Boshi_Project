using Microsoft.Xna.Framework.Input;
using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Utility;

namespace Sprint0.Commands.Mario
{
    public class CMarioMoveLeft : ICommand
    {
        private Sprint0 sprint;
        private IMario mario;
        private LevelLoader1 level;
        private GameStats hud;
        private HudNumbers numbers;
        public CMarioMoveLeft(Sprint0 sprint, LevelLoader1 level, GameStats hud)
        {
            this.sprint = sprint;
            this.hud = hud;
            this.level = level;
            numbers = new HudNumbers();
            mario = level.mario;
        }
        public void Execute()
        {
            // set mario's direction
            mario.facingLeft = true;

            // if mario has raccoon power, start running timer, else reset
            if (mario.health == Characters.Mario.MarioHealth.Raccoon && mario.pose == Characters.Mario.MarioPose.Walking)
            {
                SetPower();
                mario.runningTimer++;
            }
            else
            {
                SetPower();
                mario.runningTimer = 0;
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
