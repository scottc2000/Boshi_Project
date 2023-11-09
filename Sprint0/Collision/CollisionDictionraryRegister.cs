using Sprint0.Blocks;
using Sprint0.Characters;
using Sprint0.Commands.Collision;
using Sprint0.Commands.Collisions;
using Sprint0.Commands.Mario;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sprint0.Collision
{

    public class CollisionDictionraryRegister
    {
        public CollisionDictionary collisions;
        public Sprint0 sprint;

        //Collision Commands
        

        public CollisionDictionraryRegister(Sprint0 sprint)
        {
            collisions = new CollisionDictionary();
            this.sprint = sprint;
        }

        public void generate()
        {
            //(icollidable, icollidable, side), (constructorinfo, constructorinfo))
            //collisions.collision.Add();
        }
    }
}