using Sprint0.Interfaces;

namespace Sprint0.Commands.Player
{
    public class CDeadPlayer : ICommand
    {
        private IPlayer player;

        public CDeadPlayer(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.health = Characters.Player.PlayerHealth.Dead;
            player.Die();
        }
    }
}
