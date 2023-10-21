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
            collisions.playerPlayerDict.Add(new Tuple<List<ICharacter>, List<ICharacter>, CollisionDictionary.Side>(this.sprint.objects.Players, this.sprint.objects.Players, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioStop(sprint), new CLuigiStuckX(sprint)));




            //collisions.playerPlayerDict.Add(new Tuple<List<ICharacter>, List<ICharacter>, CollisionDictionary.Side>(this.sprint.objects.Players, this.sprint.objects.Players, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioStop(sprint), new CLuigiStuckX(sprint)));
            //Needs every possible collision combination registered
        }
    }
}
