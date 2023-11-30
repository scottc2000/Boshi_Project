using Sprint0.HUD;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Player
{
    public class CPlayerJump : ICommand
    {
        private IPlayer player;
        private GameStats hud;
        public CPlayerJump(IPlayer player, GameStats hud)
        {
            this.player = player;
            this.hud = hud;
        }
        public void Execute()
        {
            if (player.boosted)
            {
                ICommand flyCommand = new CPlayerFly(player, hud);
                flyCommand.Execute();
            }
            else
            {
                player.Jump();
            }


        }

    }
}