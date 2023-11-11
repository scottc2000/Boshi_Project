using Sprint0.Interfaces;
using Sprint0.Characters;
using System;

namespace Sprint0.Commands.Luigi
{
    public class CLuigiFly : ICommand
    {
        private Sprint0 mySprint0;
        private ILuigi luigi;
        private LevelLoader1 level;

        public CLuigiFly(Sprint0 Sprint0, LevelLoader1 level)
        {
            mySprint0 = Sprint0;
            this.level = level;
            luigi = level.luigi;
        }
        public void Execute()
        {
            if (luigi.boosted)
            {
                luigi.Fly();
            }
            else
            {
                luigi.Jump();
            }

        }
    }
}

