using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collision
{
    public class CMarioStuckX : ICommand, ICollidableCommand
    {

        private Sprint0 mySprint0;
        private IMario mario;

        public CMarioStuckX(Sprint0 mySprint0)
        {
            this.mySprint0 = mySprint0;
        }

        public void Execute()
        {
            mario = mySprint0.objects.mario;
            if (mario.facingLeft)
            {
                mario.stuck = true;
                mario.lefthit = true;
            }
            else
            {
                mario.stuck = true;
                mario.righthit = true;
            }

        }

        public void Execute(Rectangle hitbox)
        {
            mario = mySprint0.objects.mario;
            Rectangle hitarea = Rectangle.Intersect(hitbox, mario.destination);

            if (!(hitarea.Width >= hitarea.Height))
            {
                if (mario.facingLeft)
                    mario.position = new Vector2(mario.position.X + hitarea.Width, mario.position.Y);
                else
                    mario.position = new Vector2(mario.position.X - hitarea.Width, mario.position.Y);
            }
        }
    }
}