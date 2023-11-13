using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Diagnostics;

namespace Sprint0.Commands.Collision
{
    public class CPlayerStuckBottomY : ICollidableCommand
    {

        private Sprint0 mySprint0;
        private IPlayer player;

        public CPlayerStuckBottomY(Sprint0 mySprint0, IPlayer player)
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
                    player.position = new Vector2(player.position.X, player.position.Y + hitarea.Height);
                }

            }
            

        }
    }
}