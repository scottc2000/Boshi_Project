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
            collisions.luigiMario.Add(new Tuple<ICharacter, ICharacter, CollisionDictionary.Side>(this.sprint.objects.mario, this.sprint.objects.luigi, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), new CLuigiStuckX(sprint)));
            collisions.luigiMario.Add(new Tuple<ICharacter, ICharacter, CollisionDictionary.Side>(this.sprint.objects.mario, this.sprint.objects.luigi, CollisionDictionary.Side.Right), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), new CLuigiStuckX(sprint)));
            collisions.luigiMario.Add(new Tuple<ICharacter, ICharacter, CollisionDictionary.Side>(this.sprint.objects.mario, this.sprint.objects.luigi, CollisionDictionary.Side.Top), new Tuple<ICommand, ICommand>(new CMarioStuckY(sprint), new CLuigiStuckY(sprint)));
            collisions.luigiMario.Add(new Tuple<ICharacter, ICharacter, CollisionDictionary.Side>(this.sprint.objects.mario, this.sprint.objects.luigi, CollisionDictionary.Side.Bottom), new Tuple<ICommand, ICommand>(new CMarioStuckY(sprint), new CLuigiStuckY(sprint)));

            collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, this.sprint.objects.Blocks, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CLuigiStuckX(sprint), null));
            collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, this.sprint.objects.Blocks, CollisionDictionary.Side.Right), new Tuple<ICommand, ICommand>(new CLuigiStuckX(sprint), null));
            collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, this.sprint.objects.Blocks, CollisionDictionary.Side.Top), new Tuple<ICommand, ICommand>(new CLuigiStuckY(sprint), null));
            collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, this.sprint.objects.Blocks, CollisionDictionary.Side.Bottom), new Tuple<ICommand, ICommand>(new CLuigiStuckY(sprint), null));

            //collisions.playerPlayerDict.Add(new Tuple<List<ICharacter>, List<ICharacter>, CollisionDictionary.Side>(this.sprint.objects.Players, this.sprint.objects.Players, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioStop(sprint), new CLuigiStuckX(sprint)));
            //Needs every possible collision combination registered
        }
    }
}