using System;
using System.Drawing;
using Sprint0.Collision;
using Sprint0.Interfaces;

namespace Sprint0.Commands.Collision
{
    public class CMarioStuckX : ICommand
    {
        //this can be used for both mario and luigi
        //mario and luigi should have shared interface to be told how to collide (as player)
        //remove imario, change to icharacter (put side stuff from icollidable into icharacter)
        //create a parent abstract class that this derives from constructor, 3 variables, execute
        //all collision commands should look like this
        private IMario mario;

        public CMarioStuckX(ICollidable mario, ICollidable luigi, CollisionData collisionData)
        {
            //this could be error checked
            this.mario = (IMario)mario;
        }

        public void Execute()
        {
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
    }
}