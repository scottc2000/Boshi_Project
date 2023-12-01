using Sprint0.Characters;
using Sprint0.Interfaces;
using Microsoft.Xna.Framework;
namespace Sprint0.Commands.Collisions
{
    public class CMarioDie : ICommand
    {
        private Sprint0 sprint;
        private IMario mario;

        public CMarioDie(Sprint0 sprint)
        {
            this.sprint = sprint;
            mario = this.sprint.levelLoader.mario;
        }

        public void Execute()
        {
            mario.health = Characters.Mario.MarioHealth.Dead;
            mario.Die();
                        
        }

    }
}
