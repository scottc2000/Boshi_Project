using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collision
{
    public class CPlayerStuckX : ICollidableCommand
    {

        private Sprint0 mySprint0;
        private IPlayer player;

        public CPlayerStuckX(Sprint0 mySprint0, IPlayer player)
        {
            this.mySprint0 = mySprint0;
            this.player = player;
        }

        public void Execute(Rectangle hitbox)
        {
            Rectangle hitarea = Rectangle.Intersect(hitbox, player.Destination);

            if (!(hitarea.Width >= hitarea.Height))
            {
                if (player.facingLeft)
                    player.position = new Vector2(player.position.X + hitarea.Width, player.position.Y);
                else
                    player.position = new Vector2(player.position.X - hitarea.Width, player.position.Y);
            }
        }
    }
}