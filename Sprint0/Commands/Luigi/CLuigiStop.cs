using Sprint0.Interfaces;

namespace Sprint0.Commands.Luigi
{
    public class CLuigiStop : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter luigi;

        public CLuigiStop(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            luigi = mySprint0.objects.luigi;
            luigi.Stop();
        }
    }
}
