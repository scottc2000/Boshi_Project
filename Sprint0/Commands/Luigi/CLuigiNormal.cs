using Sprint0.Interfaces;


namespace Sprint0.Commands.Luigi
{
    internal class CLuigiNormal : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter luigi;
        public CLuigiNormal(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            luigi = mySprint0.objects.luigi;
            luigi.ChangeToNormal();
        }

    }
}
