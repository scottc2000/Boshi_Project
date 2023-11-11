﻿using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Luigi
{
    internal class CLuigiMoveRight : ICommand
    {
       
        private Sprint0 sprint;
        private ILuigi luigi;

        public CLuigiMoveRight(Sprint0 sprint, LevelLoader1 level)
        {
            this.sprint = sprint;
            luigi = level.luigi;
        }
        public void Execute()
        {
            luigi.facingLeft = false;
            if (luigi.health == Characters.Luigi.LuigiHealth.Raccoon && luigi.pose == Characters.Luigi.LuigiPose.Walking)
                luigi.runningTimer++;
            else
                luigi.runningTimer = 0;

            luigi.Move();

            
        }
    }
}

