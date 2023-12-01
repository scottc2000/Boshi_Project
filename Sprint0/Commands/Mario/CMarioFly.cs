using Sprint0.Interfaces;
using Sprint0.Characters;
using Sprint0.HUD;
using Sprint0.Utility;

namespace Sprint0.Commands.Mario
{
    public class CMarioFly : ICommand 
    {
        private Sprint0 mySprint0;
        private IMario mario;
        private GameStats hud;
        private HudNumbers numbers;

        public CMarioFly(Sprint0 Sprint0, GameStats hud)
        {
            mySprint0 = Sprint0;
            this.hud = hud;
            numbers = new HudNumbers();
            mario = mySprint0.levelLoader.mario;
        }
        public void Execute()
        {
            if (mario.boosted)
            {
                hud.PowerLevel(numbers.level4);
                mario.Fly();
            }
            else
            {
                mario.Jump();
            }

        }


    }
}

