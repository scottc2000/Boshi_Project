using Sprint0.Interfaces;
using Sprint0.GameMangager;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands.Collisions
{
    internal class CBlockBump : ICommand
    {
        private Sprint0 myGame;
        private ObjectManager objectManager;
        private IBlock block;
        private Rectangle local;

        public CBlockBump(Sprint0 myGame)
        {
            this.myGame = myGame;
            objectManager = myGame.objects;
            local = block.Destination;
        }

        public void Execute()
        {
            
        }
    }
}
