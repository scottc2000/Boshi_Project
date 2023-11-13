using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collision
{
    public class CPlayerStuckTopY : ICollidableCommand
    {

        private Sprint0 mySprint0;
        private IPlayer player;

        public CPlayerStuckTopY(Sprint0 mySprint0, IPlayer player)
        {
            this.mySprint0 = mySprint0;
            this.player = player;
        }

        public void Execute(Rectangle hitbox)
        {
            Rectangle hitarea = Rectangle.Intersect(hitbox, player.Destination);

            if (hitarea.Width >= hitarea.Height)
            {
                if (player.Destination.Top <= hitbox.Bottom && player.Destination.Bottom >= hitbox.Top + 5)
                {
                    
                }
                else
                {
                    player.uphit = true;
                    player.position = new Vector2(player.position.X, player.position.Y - hitarea.Height);
                }

            }
            

        }
    }
}