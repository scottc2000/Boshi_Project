using Sprint0.Interfaces;

namespace Sprint0.Commands.Player
{
    public class CPlayerFly : ICommand
    {
        private IPlayer player;

        public CPlayerFly(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            if (player.boosted)
            {
                player.Fly();
            }
            else
            {
                player.Jump();
            }

        }
    }
}

