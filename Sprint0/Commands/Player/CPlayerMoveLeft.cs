using Sprint0.HUD;
using Sprint0.Interfaces;
using Sprint0.Utility;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace Sprint0.Commands.Player
{
    public class CPlayerMoveLeft : ICommand
    {
        private IPlayer player;
        private GameStats stats;
        private HudNumbers numbers;
        Sprint0 sprint;
        public CPlayerMoveLeft(IPlayer player, GameStats hud, Sprint0 sprint)
        {
            this.player = player;
            stats = hud;
            numbers = new HudNumbers();
            this.sprint = sprint;
        }
        public void Execute()
        {
            player.facingLeft = true;
            if (player.health == Characters.Player.PlayerHealth.Raccoon && player.pose == Characters.Player.PlayerPose.Walking)
            {
                player.runningTimer++;
            }
            else
            {
                player.runningTimer = 0;
            }

            SetPower();
            player.Move();
            sprint.detector.DetectCollision();

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
