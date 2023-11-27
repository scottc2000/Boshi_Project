using Sprint0.Interfaces;
using Sprint0.HUD;
using Sprint0.GameMangager;

namespace Sprint0.Commands.Collisions
{
    public class CItemAppear : ICommand
    {
        private Sprint0 sprint;
        private ObjectManager objectManager;
        private GameStats stats;

        public CItemAppear(Sprint0 sprint)
        {
            this.sprint = sprint;
            objectManager = sprint.objects;
            stats = sprint.levelLoader.hud;
        }
        public void Execute()
        {

        }

        public void Execute(IItem item)
        {
            objectManager.AddToList(item);
        }
    }
}
