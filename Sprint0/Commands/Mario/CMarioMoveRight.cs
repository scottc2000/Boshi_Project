﻿using Sprint0.Interfaces;

namespace Sprint0.Commands
{
    public class CMarioMoveRight : ICommand
    {
       
        private Sprint0 sprint;
        private IMario mario;

        public CMarioMoveRight(Sprint0 sprint, LevelLoader1 level)
        {
            this.sprint = sprint;
            mario = level.mario;
        }
        public void Execute()
        {
            // set mario's direction
            mario.facingLeft = false;

            // if mario has raccoon power, start running timer, else reset
            if (mario.health == Characters.Mario.MarioHealth.Raccoon && mario.pose == Characters.Mario.MarioPose.Walking)
                mario.runningTimer++;
            else
                mario.runningTimer = 0;

            // call mario's move method
            mario.Move();
        }
    }
}
