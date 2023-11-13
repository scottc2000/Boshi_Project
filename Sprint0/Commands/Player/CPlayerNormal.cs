using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Player
{
    public class CPlayerNormal : ICommand
    {
        private IPlayer player;
        public CPlayerNormal(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.ChangeToNormal();
        }

    }
}
