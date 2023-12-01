using Sprint0.Interfaces;
using Sprint0.Characters;
using System;
using Sprint0.HUD;
using Sprint0.Utility;

namespace Sprint0.Commands.Luigi
{
    public class CLuigiFly : ICommand
    {
        private Sprint0 mySprint0;
        private ILuigi luigi;
        private GameStats hud;
        private HudNumbers numbers;

        public CLuigiFly(Sprint0 Sprint0, LevelLoader1 level, GameStats hud)
        {
            mySprint0 = Sprint0;
            luigi = level.luigi;
            this.hud = hud;
            numbers = new HudNumbers();
        }
        public void Execute()
        {
            if (luigi.boosted)
            {
                hud.PowerLevel(numbers.level4);
                luigi.Fly();
            }
            else
            {
                luigi.Jump();
            }

        }
    }
}

