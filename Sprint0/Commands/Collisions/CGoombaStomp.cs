using Sprint0.Characters;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework;
using Sprint0.Enemies;
using System.Runtime.Serialization;
using Sprint0.Utility;
using Sprint0.HUD;

namespace Sprint0.Commands.Collisions
{
    public class CGoombaStomp : ICommand
    {
        private Sprint0 sprint;
        private Goomba goomba;
        private HudNumbers numbers;
        private GameStats stats;
        ObjectManager objectManager;

        public CGoombaStomp(Sprint0 sprint)
        {
            this.sprint = sprint;
            stats = sprint.hud;
            numbers = new HudNumbers();
            //objectManager = sprint.objects;
        }

        public void Execute()
        {
            stats.IncreaseScore(numbers.enemyPoints);
            goomba.BeStomped();       
        }

    }
}
