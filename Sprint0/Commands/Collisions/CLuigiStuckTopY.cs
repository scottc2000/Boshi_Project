using System;
using Microsoft.Xna.Framework;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CLuigiStuckTopY : ICommand, ICollidableCommand
    {

        private Sprint0 mySprint0;
        private ILuigi luigi;

        public CLuigiStuckTopY(Sprint0 mySprint0)
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
                    
                                              
                }
                else
                {
                    luigi.uphit = true;
                    luigi.position = new Vector2(luigi.position.X, luigi.position.Y - hitarea.Height);
                }
            }
            
        }
    }
}

