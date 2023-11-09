using System;
using Microsoft.Xna.Framework;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CLuigiStuckX : ICommand, ICollidableCommand
    {

        private Sprint0 mySprint0;
        Characters.Luigi luigi;

        public CLuigiStuckX(Sprint0 mySprint0)
        {
            this.mySprint0 = mySprint0;
        }

        public void Execute()
        {

            luigi = mySprint0.objects.luigi;

            if (luigi.facingLeft)
            {
                luigi.stuck = true;
                luigi.lefthit = true;
            }
            else
            {
                luigi.stuck = true;
                luigi.righthit = true;
            }

            
        }

        public void Execute(Rectangle hitbox)
        {
            luigi = mySprint0.objects.luigi;

            Rectangle hitarea = Rectangle.Intersect(hitbox, luigi.Destination);

            if (!(hitarea.Width >= hitarea.Height))
            {
                if (luigi.facingLeft)
                {
                    luigi.position.X += hitarea.Width;
                }
                else
                {
                    luigi.position.X -= hitarea.Width;
                }
            }
        }
    }
}

