using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Player
{
    public class CPlayerFire : ICommand
    {
        private IPlayer player;
        public CPlayerFire(IPlayer plaer)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.ChangeToFire();
        }

    }
}
