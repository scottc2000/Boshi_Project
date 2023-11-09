using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collision
{
    public class CMarioStuckY : ICommand, ICollidableCommand
    {

        private Sprint0 mySprint0;
        private IMario mario;

        public CMarioStuckY(Sprint0 mySprint0)
        {
            this.mySprint0 = mySprint0;
        }

        public void Execute()
        {
            mario = mySprint0.levelLoader.mario;
            mario.uphit = true;
        }

        public void Execute(Rectangle hitbox)
        {
            mario = mySprint0.levelLoader.mario;
            Rectangle hitarea = Rectangle.Intersect(hitbox, mario.Destination);

            if (hitarea.Width >= hitarea.Height)
            {
                if (hitbox.Y <= mario.position.Y)
                {
                    mario.position = new Vector2(mario.position.X, mario.position.Y + hitarea.Height);

                }
                else
                {
                    mario.uphit = true;
                    mario.position = new Vector2(mario.position.X, mario.position.Y - hitarea.Height);
                }
            }

        }
    }
}