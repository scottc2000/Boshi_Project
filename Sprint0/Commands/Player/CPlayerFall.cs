using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Player
{
    public class CPlayerFall : ICommand
    {
        private IPlayer player;
        public CPlayerFall(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        { 
            player.Fall();
            player.flyingTimer = 0;
        }
    }
}