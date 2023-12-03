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
            //local = new Rectangle();
            //local = block.Destination;
        }

        public void Execute()
        {

        }
        public void Execute(IBlock block)
        {
            block.Destination = new Rectangle(block.Destination.X, block.Destination.Y - 1, block.Destination.Width, block.Destination.Height);
            block.Destination = new Rectangle(block.Destination.X, block.Destination.Y + 1, block.Destination.Width, block.Destination.Height);
        }
    }
}
