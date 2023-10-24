using Sprint0.Interfaces;

namespace Sprint0.Commands.Luigi
{
    public class CReleasedLuigi : ICommand
    {
        private Sprint0 mySprint;
        private ICharacter luigi;

        public CReleasedLuigi(Sprint0 sprint0) 
        { 
            mySprint = sprint0;

        }

        public void Execute()
        {
            luigi = mySprint.objects.Players[1];
            luigi.Stop();
        }

    }
}
