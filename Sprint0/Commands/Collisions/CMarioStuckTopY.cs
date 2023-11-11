﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using System.Diagnostics;

namespace Sprint0.Commands.Collision
{
    public class CMarioStuckTopY : ICommand, ICollidableCommand
    {

        private Sprint0 mySprint0;
        private IMario mario;

        public CMarioStuckTopY(Sprint0 mySprint0)
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
                if (mario.Destination.Top <= hitbox.Bottom && mario.Destination.Bottom >= hitbox.Top + 5)
                {
                    
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