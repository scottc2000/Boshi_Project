using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Player
{
    public class CPlayerThrow : ICommand
    {
        private IPlayer player;
        public CPlayerThrow(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.Throw();
            
        }

    }
}
