using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Player
{
    public class CPlayerRaccoon : ICommand
    {
        private IPlayer player;
        public CPlayerRaccoon(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.ChangeToRaccoon();
        }

    }
}