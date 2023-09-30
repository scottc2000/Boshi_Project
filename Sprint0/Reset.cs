using Sprint0.Blocks;
using Sprint0.Characters;
using Sprint0.Interfaces;
using Sprint0.Sprites;

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
            mySprint.luigi = new Luigi(mySprint);
        }

    }
}
