using Sprint0.Characters;
using Sprint0.Blocks;
using Sprint0.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Sprint0.Commands.Luigi;
using Sprint0.Commands.Mario;
using Sprint0.Commands;

namespace Sprint0.Collision
{

    public class CollisionDictionraryRegister
    {
        public CollisionDictionary collisions;
        public Sprint0 sprint;

        public CollisionDictionraryRegister(Sprint0 sprint)
        {
            collisions = new CollisionDictionary();
            this.sprint = sprint;
        }

        public void generate()
        {
            collisions.RegisterCommand(new Tuple<ICollidable, ICollidable, CollisionDictionary.Side>(sprint.objects.Players[0], sprint.objects.Players[1], CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioStop(sprint), new CLuigiStuckX(sprint)));
            collisions.RegisterCommand(new Tuple<ICollidable, ICollidable, CollisionDictionary.Side>(sprint.objects.Players[1], sprint.objects.Players[0], CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CLuigiStuckX(sprint), new CMarioStop(sprint)));
            //Needs every possible collision combination registered
        }
    }
}
