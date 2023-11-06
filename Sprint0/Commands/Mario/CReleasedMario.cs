using Sprint0.Interfaces;

namespace Sprint0.Commands.Mario
{
    public class CReleasedMario : ICommand
    {
        private Sprint0 mySprint;
        private IMario mario;

        public CReleasedMario(Sprint0 sprint0) 
        { 
            mySprint = sprint0;

        }

        public void Execute()
        {
            mario = mySprint.objects.mario;
            mario.Stop();
        }

    }
}
