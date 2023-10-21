using Sprint0.Commands.Collision;
using Sprint0.Commands.Collisions;
using Sprint0.Commands.Mario;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;

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
            collisions.playerPlayerDict.Add(new Tuple<List<ICharacter>, List<ICharacter>, CollisionDictionary.Side>(this.sprint.objects.Players, this.sprint.objects.Players, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), new CLuigiStuckX(sprint)));
            collisions.playerPlayerDict.Add(new Tuple<List<ICharacter>, List<ICharacter>, CollisionDictionary.Side>(this.sprint.objects.Players, this.sprint.objects.Players, CollisionDictionary.Side.Right), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), new CLuigiStuckX(sprint)));
            collisions.playerPlayerDict.Add(new Tuple<List<ICharacter>, List<ICharacter>, CollisionDictionary.Side>(this.sprint.objects.Players, this.sprint.objects.Players, CollisionDictionary.Side.Top), new Tuple<ICommand, ICommand>(new CMarioStop(sprint), new CLuigiStuckY(sprint)));



            //collisions.playerPlayerDict.Add(new Tuple<List<ICharacter>, List<ICharacter>, CollisionDictionary.Side>(this.sprint.objects.Players, this.sprint.objects.Players, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioStop(sprint), new CLuigiStuckX(sprint)));
            //Needs every possible collision combination registered
        }
    }
}