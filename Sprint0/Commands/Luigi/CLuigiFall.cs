﻿using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Luigi
{
    internal class CLuigiFall : ICommand
    {
        private Sprint0 sprint;
        private ILuigi luigi;
        public CLuigiFall(Sprint0 sprint, LevelLoader1 level)
        {
            this.sprint = sprint;
            luigi = level.luigi;
        }
        public void Execute()
        { 
  
            luigi.Fall();
            luigi.flyingTimer = 0;

        }

    }
}