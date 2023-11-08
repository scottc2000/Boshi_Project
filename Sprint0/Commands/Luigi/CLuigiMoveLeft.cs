using Sprint0.Interfaces;

namespace Sprint0.Commands.Luigi
{
    internal class CLuigiMoveLeft : ICommand
    {
        private Sprint0 mySprint0;
        private ICharacter luigi;
        public CLuigiMoveLeft(Sprint0 Sprint0)
        {
            mySprint0 = Sprint0;
        }
        public void Execute()
        {
            luigi = mySprint0.objects.luigi;
            luigi.facingLeft = true;
            
            luigi.Move();
            
        }

    }
}
