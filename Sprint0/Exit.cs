using Sprint0.Interfaces;

namespace Sprint0
{
    internal class Exit : ICommand
    {
        private Sprint0 mySprint0;
        public Exit(Sprint0 game) { 
            mySprint0 = game;
        }
        public void Execute() 
        {
            mySprint0.Exit();
        }

    }
}
