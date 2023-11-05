using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{

    public class CMarioFire : ICommand
    {
        private Sprint0 mySprint0;
        private IMario mario;
        public CMarioFire(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {

            mario = mySprint0.objects.mario;
            mario.ChangeToFire();
        }

    }
}
