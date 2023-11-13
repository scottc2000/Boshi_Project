using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Player
{
    public class CPlayerStop : ICommand
    {
        private IPlayer player;

        public CPlayerStop(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.Stop();
            
        }
    }
}
