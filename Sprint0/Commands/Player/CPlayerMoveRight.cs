using Sprint0.Interfaces;
using System.Reflection.Emit;

namespace Sprint0.Commands.Player
{
    public class CPlayerMoveRight : ICommand
    {
        private IPlayer player;
        public CPlayerMoveRight(IPlayer player)
        {
            this.player = player;
        }
        public void Execute()
        {
            player.facingLeft = false;
            if (player.health == Characters.Player.PlayerHealth.Raccoon && player.pose == Characters.Player.PlayerPose.Walking)
                player.runningTimer++;
            else
                player.runningTimer = 0;

            player.Move();

            
        }
    }
}

