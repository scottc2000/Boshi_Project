using Sprint0.Interfaces;

namespace Sprint0.Commands.Player
{
    public class CPlayerBig : ICommand
    {
        private IPlayer player;
        public CPlayerBig(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.ChangeToBig();

        }

    }
}
