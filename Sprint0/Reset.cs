using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0
{
    internal class Reset : ICommand
    {
        private Sprint0 mySprint;
        public Reset(Sprint0 game) { 
            mySprint = game;
        }
        public void Execute() 
        {
            mySprint.mario = new Mario(mySprint);
        }

    }
}
