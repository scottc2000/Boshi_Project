using Sprint0.Interfaces;
using Sprint0.Characters;

namespace Sprint0.Commands.Mario
{
    public class CMarioFly : ICommand 
    {
        private Sprint0 mySprint0;
        private IMario mario;
        private LevelLoader1 level;

        public CMarioFly(Sprint0 Sprint0, LevelLoader1 level)
        {
            mySprint0 = Sprint0;
            this.level = level;
            mario = level.mario;
        }
        public void Execute()
        {
            if (mario.boosted)
            {
                mario.Fly();
            }
            else
            {
                mario.Jump();
            }

        }
    }
}

