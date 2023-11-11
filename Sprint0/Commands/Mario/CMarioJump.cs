using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{
    public class CMarioJump : ICommand
    {
        private Sprint0 mySprint0;
        private IMario mario;
        private LevelLoader1 level;
        public CMarioJump(Sprint0 Sprint0, LevelLoader1 level)
        {
            mySprint0 = Sprint0;
            this.level = level;
        }
        public void Execute()
        {
            mario = level.mario;
            if (mario.health == Characters.Mario.MarioHealth.Raccoon)
            {
                ICommand flyCommand = new CMarioFly(mySprint0, level);
                flyCommand.Execute();
            }
            else
            {
                mario.Jump();
            }
        }
    }
}