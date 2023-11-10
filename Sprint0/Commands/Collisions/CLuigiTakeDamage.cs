using Sprint0.Characters;
using Sprint0.Interfaces;

using Sprint0.Characters;
using Sprint0.Interfaces;
using static Sprint0.Sprites.Players.PlayerData;

namespace Sprint0.Commands.Collisions
{
    public class CLuigiTakeDamage : ICommand
    {
        private Sprint0 sprint;
        private ILuigi luigi;

        public CLuigiTakeDamage(Sprint0 sprint)
        {
            this.sprint = sprint;
            luigi = this.sprint.levelLoader.luigi;
        }

        public void Execute()
        {
            switch (luigi.health)
            {
                case Characters.Luigi.LuigiHealth.Normal:
                    {
                        luigi.Die();
                        break;
                    }
                case Characters.Luigi.LuigiHealth.Big:
                    {
                        ILuigi luigidamanged = new DamagedLuigi(luigi, sprint.levelLoader);
                        luigidamanged.isInvinsible = true; // Set Luigi as invincible
                        sprint.levelLoader.luigi = luigidamanged;
                        luigi.ChangeToNormal();
                        break;
                    }
                case Characters.Luigi.LuigiHealth.Fire:
                    {
                        ILuigi luigidamanged = new DamagedLuigi(luigi, sprint.levelLoader);
                        luigidamanged.isInvinsible = true; // Set Luigi as invincible
                        sprint.levelLoader.luigi = luigidamanged;
                        luigi.ChangeToBig();
                        break;
                    }
                case Characters.Luigi.LuigiHealth.Raccoon:
                    {
                        ILuigi luigidamanged = new DamagedLuigi(luigi, sprint.levelLoader);
                        luigidamanged.isInvinsible = true; // Set Luigi as invincible
                        sprint.levelLoader.luigi = luigidamanged;
                        luigi.ChangeToBig();
                        break;
                    }
            }
        }

    }
}
