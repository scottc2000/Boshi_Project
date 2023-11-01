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

            luigi = mySprint0.objects.luigi;
            luigi.uphit = true;
        }

        public void Execute(Rectangle hitbox)
        {
            luigi = mySprint0.objects.luigi;

            if (hitbox.Width >= hitbox.Height)
            {
                if (hitbox.Y <= luigi.position.Y)
                {
                    luigi.position.Y += hitbox.Height;
                    luigi.velocityY *= -1;

                }
                else
                {
                    luigi.uphit = true;
                    luigi.position.Y -= hitbox.Height;
                }
            }
            
        }
    }
}

