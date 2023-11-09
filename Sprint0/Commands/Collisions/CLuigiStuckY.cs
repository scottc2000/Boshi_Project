using System;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CLuigiStuckY : ICommand, ICollidableCommand
    {

        private Sprint0 mySprint0;
        private Characters.Luigi luigi;

        public CLuigiStuckY(Sprint0 mySprint0)
        {
            this.mySprint0 = mySprint0;
        }

        public void Execute()
        {

            luigi = mySprint0.levelLoader.luigi;
            luigi.uphit = true;

        }

        public void Execute(Rectangle hitbox)
        {
            luigi = mySprint0.levelLoader.luigi;

            Rectangle hitarea = Rectangle.Intersect(hitbox, luigi.Destination);

            if (hitarea.Width >= hitarea.Height)
            {
                if (hitbox.Y <= luigi.position.Y)
                {
                    luigi.position.Y += hitarea.Height;
                                              
                }
                else
                {
                    luigi.uphit = true;
                    luigi.position.Y -= hitarea.Height;
                }
            }
            
        }
    }
}

