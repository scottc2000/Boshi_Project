using Sprint0.Characters;
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
            // mario luigi collisions
            collisions.luigiMario.Add(new Tuple< IMario, ICharacter, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.luigi, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), new CLuigiStuckX(sprint)));
            collisions.luigiMario.Add(new Tuple<IMario, ICharacter, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.luigi, CollisionDictionary.Side.Right), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), new CLuigiStuckX(sprint)));
            collisions.luigiMario.Add(new Tuple<IMario, ICharacter, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.luigi, CollisionDictionary.Side.Top), new Tuple<ICommand, ICommand>(new CMarioStuckY(sprint), new CLuigiStuckY(sprint)));
            collisions.luigiMario.Add(new Tuple<IMario, ICharacter, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.luigi, CollisionDictionary.Side.Bottom), new Tuple<ICommand, ICommand>(new CMarioStuckY(sprint), new CLuigiStuckY(sprint)));

            // luigi block collisions
            collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, sprint.objects.Blocks, CollisionDictionary.Side.Left), new Tuple<ICollidableCommand, ICommand>(new CLuigiStuckX(sprint), null));
            collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, sprint.objects.Blocks, CollisionDictionary.Side.Right), new Tuple<ICollidableCommand, ICommand>(new CLuigiStuckX(sprint), null));
            collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, sprint.objects.Blocks, CollisionDictionary.Side.Top), new Tuple<ICollidableCommand, ICommand>(new CLuigiStuckY(sprint), null));
            collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, sprint.objects.Blocks, CollisionDictionary.Side.Bottom), new Tuple<ICollidableCommand, ICommand>(new CLuigiStuckY(sprint), null));

            // mario block collisions
            collisions.marioBlock.Add(new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Blocks, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), null));
            collisions.marioBlock.Add(new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Blocks, CollisionDictionary.Side.Right), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), null));
            collisions.marioBlock.Add(new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Blocks, CollisionDictionary.Side.Top), new Tuple<ICommand, ICommand>(new CMarioStuckY(sprint), null));
            collisions.marioBlock.Add(new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Blocks, CollisionDictionary.Side.Bottom), new Tuple<ICommand, ICommand>(new CMarioStuckY(sprint), null));

            // mario enemy collision
            collisions.marioEnemy.Add(new Tuple<IMario, List<IEnemies>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Enemies, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioTakeDamage(sprint), null));
            collisions.marioEnemy.Add(new Tuple<IMario, List<IEnemies>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Enemies, CollisionDictionary.Side.Right), new Tuple<ICommand, ICommand>(new CMarioTakeDamage(sprint), null));

            // mario item collision
            collisions.marioItem.Add(new Tuple<IMario, List<IItem>, CollisionDictionary.Side>(sprint.objects.mario, this.sprint.objects.Items, CollisionDictionary.Side.Any), new Tuple<ICommand, ICommand>(null, new CItemDisappear(sprint)));
        }
    }
}