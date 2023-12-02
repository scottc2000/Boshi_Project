using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Utility;
using System.Reflection.Emit;

namespace Sprint0.Commands.Player
{
    public class CPlayerMoveRight : ICommand
    {
        private IPlayer player;
        private GameStats stats;
        private HudNumbers numbers;
        public CPlayerMoveRight(IPlayer player, GameStats hud)
        {
            this.player = player;
            stats = hud;
            numbers = new HudNumbers();
        }
        public void Execute()
        {
            player.facingLeft = false;
            if (player.health == Characters.Player.PlayerHealth.Raccoon && player.pose == Characters.Player.PlayerPose.Walking)
            {
                player.runningTimer++;
                SetPower();
            }
            else
            {
                player.runningTimer = 0;
                SetPower();
            }

            player.Move();     
        }

        public void SetPower()
        {
            if (player.runningTimer == 0)
                stats.PowerLevel(numbers.level0);
            else if (player.runningTimer < 25)
                stats.PowerLevel(numbers.level1);
            else if (player.runningTimer > 25 && player.runningTimer < 50)
                stats.PowerLevel(numbers.level2);
            else if (player.runningTimer > 50)
                stats.PowerLevel(numbers.level3);
        }
    }
}

