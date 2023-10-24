using Sprint0.Interfaces;

namespace Sprint0.Commands.Luigi
{
    internal class CLuigiBig : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter luigi;
        public CLuigiBig(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {

            luigi = mySprint0.objects.Players[1];
            luigi.ChangeToBig();

        }

    }
}
