using Sprint0.Interfaces;
using Sprint0.GameMangager;

namespace Sprint0.Commands.Collisions
{
    internal class CItemBlockX : ICommand
    {
        private Sprint0 myGame;
        private ObjectManager objectManager;
        private IBlock block;
        private IItem item;

        public CItemBlockX(Sprint0 myGame)
        {
            this.myGame = myGame;
            objectManager = myGame.objects;
        }

        public void Execute()
        {
            objectManager.RemoveFromList(block);
        }
    }
}

