using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0
{
    internal class Reset : ICommand
    {
        private Sprint0 mySprint;

        public Reset(Sprint0 game)
        {
            mySprint = game;
        }
        public void Execute()
        {
            // Error CS0118 when moving Reset.cs file to Commands folder
            mySprint.mario = new Mario(mySprint);
        }

    }
}
