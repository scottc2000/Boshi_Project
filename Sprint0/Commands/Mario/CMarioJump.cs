using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{
    public class CMarioJump : ICommand
    {
        private Sprint0 mySprint0;
        private IMario mario;
        public CMarioJump(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            mario = mySprint0.objects.mario;
            if (mario.health == Characters.Mario.MarioHealth.Raccoon && mario.runningTimer == 75)
                mario.Fly();
            else
                mario.Jump();
        }

    }
}