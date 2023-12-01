using Sprint0.HUD;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{
    public class CMarioJump : ICommand
    {
        private Sprint0 mySprint0;
        private IMario mario;
        private LevelLoader1 level;
        private GameStats hud;
        public CMarioJump(Sprint0 Sprint0, LevelLoader1 level, GameStats hud)
        {
            mySprint0 = Sprint0;
            this.level = level;
            this.hud = hud;
        }
        public void Execute()
        {
            mario = level.mario;
            if (mario.health == Characters.Mario.MarioHealth.Raccoon)
            {
                ICommand flyCommand = new CMarioFly(mySprint0, hud);
                flyCommand.Execute();
            }
            else
            {
                mario.Jump();
            }
        }
    }
}