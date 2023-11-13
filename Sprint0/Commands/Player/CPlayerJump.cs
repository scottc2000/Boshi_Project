using Sprint0.Interfaces;

namespace Sprint0.Commands.Player
{
    public class CPlayerJump : ICommand
    {
        private IPlayer player;
        public CPlayerJump(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            if (player.health == Characters.Player.PlayerHealth.Raccoon)
            {
                ICommand flyCommand = new CPlayerFly(player);
                flyCommand.Execute();
            }
            else
            {
                player.Jump();
            }


        }

    }
}