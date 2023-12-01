using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Player
{
    public class CPlayerCrouch : ICommand
    {
        private IPlayer player;
        public CPlayerCrouch(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.Crouch();

        }

    }
}
