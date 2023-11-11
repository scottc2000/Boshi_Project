using Sprint0.Interfaces;
using Sprint0.GameMangager;
using Microsoft.Xna.Framework;

namespace Sprint0.Commands.Collisions
{
    internal class CBlockBreak : ICommand
    {
        private Sprint0 myGame;
        private ObjectManager objectManager;
        private IBlock block;
        private Rectangle local;

        public CBlockBreak(Sprint0 myGame)
        {
            this.myGame = myGame;
            objectManager = myGame.objects;
            local = block.Destination;
        }

        public void Execute()
        {

        }

        public void Execute(IBlock block)
        {
            objectManager.RemoveFromList(block);
        }
    }
}
