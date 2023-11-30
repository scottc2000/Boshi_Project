using Sprint0.Characters;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Sprint0.Enemies;
using Sprint0.GameMangager;

namespace Sprint0.Commands.Collisions
{
    public class CEnemyStomp : ICommand
    {
        private Sprint0 sprint;
        private IEnemies enemy;
        private ObjectManager objectManager;

        public CEnemyStomp(Sprint0 sprint, IEnemies enemy)
        {
            this.sprint = sprint;
            this.enemy = enemy;
            objectManager = sprint.objects;
        }

        public void Execute()
        {
            enemy.BeStomped();
            objectManager.RemoveFromList(enemy);
        }

    }
}
