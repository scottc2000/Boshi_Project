using Sprint0.Interfaces;
using Sprint0.HUD;
using Sprint0.GameMangager;

namespace Sprint0.Commands.Collisions
{
    public class CQuestionBump : ICommand
    {
        private Sprint0 sprint;
        private ObjectManager objectManager;
        private GameStats stats;

        public CQuestionBump(Sprint0 sprint)
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
