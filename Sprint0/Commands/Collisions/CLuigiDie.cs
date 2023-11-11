using Sprint0.Characters;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework;
namespace Sprint0.Commands.Collisions
{
    public class CLuigiDie : ICommand
    {
        private Sprint0 sprint;
        private ILuigi luigi;

        public CLuigiDie(Sprint0 sprint)
        {
            this.sprint = sprint;
            luigi = this.sprint.levelLoader.luigi;
        }

        public void Execute()
        {
            luigi.health = Characters.Luigi.LuigiHealth.Dead;
            luigi.Die();
                        
        }

    }
}
