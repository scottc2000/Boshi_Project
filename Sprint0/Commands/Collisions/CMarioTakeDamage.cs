using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CMarioTakeDamage : ICommand
    {
        private Sprint0 sprint;
        private IMario mario;

        public CMarioTakeDamage(Sprint0 sprint)
        {
            this.sprint = sprint;
            mario = this.sprint.levelLoader.mario;
        }

        public void Execute()
        {
            mario.gothit = true;
            switch (mario.health)
            {
                case Characters.Mario.MarioHealth.Normal:
                    {
                        mario.health = Characters.Mario.MarioHealth.Dead;
                        mario.Die();
                        break;
                    }
                case Characters.Mario.MarioHealth.Big:
                    {
                        IMario damagedMario = new DamagedMario(mario, sprint.objects);
                        damagedMario.isInvinsible = true; // Set Mario as invincible
                        sprint.levelLoader.mario = damagedMario; // Update the game manager to use DamagedMario
                        mario.ChangeToNormal();
                        break;
                    }
                case Characters.Mario.MarioHealth.Fire:
                    {
                        IMario damagedMario = new DamagedMario(mario, sprint.objects);
                        damagedMario.isInvinsible = true; // Set Mario as invincible
                        sprint.levelLoader.mario = damagedMario; // Update the game manager to use DamagedMario
                        mario.ChangeToBig();
                        break;
                    }
                case Characters.Mario.MarioHealth.Raccoon:
                    {
                        IMario damagedMario = new DamagedMario(mario, sprint.objects);
                        damagedMario.isInvinsible = true; // Set Mario as invincible
                        sprint.levelLoader.mario = damagedMario; // Update the game manager to use DamagedMario
                        mario.ChangeToBig();
                        break;
                    }
            }
        }

    }
}
