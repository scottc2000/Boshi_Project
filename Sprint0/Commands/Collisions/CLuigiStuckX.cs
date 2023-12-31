﻿using System;
using Microsoft.Xna.Framework;
using Sprint0.Characters;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collisions
{
    public class CLuigiStuckX : ICommand, ICollidableCommand
    {

        private Sprint0 mySprint0;
        ILuigi luigi;

        public CLuigiStuckX(Sprint0 mySprint0)
        {
            this.mySprint0 = mySprint0;
        }

        public void Execute()
        {

            luigi = mySprint0.levelLoader.luigi;

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
            luigi = mySprint0.levelLoader.luigi;

            Rectangle hitarea = Rectangle.Intersect(hitbox, luigi.Destination);

            if (!(hitarea.Width >= hitarea.Height))
            {
                if (luigi.facingLeft)
                {
                    luigi.position = new Vector2(luigi.position.X + hitarea.Width, luigi.position.Y);
                }
                else
                {
                    luigi.position = new Vector2(luigi.position.X - hitarea.Width, luigi.position.Y);
                }
            }
        }
    }
}

