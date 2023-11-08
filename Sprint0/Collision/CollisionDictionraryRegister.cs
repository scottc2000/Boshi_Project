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
            Action<IEntity, IEntity> luigiStuckX = callLuigiStuckX;
            Action<IEntity, IEntity> luigiStuckY = callLuigiStuckY;
            // mario luigi collisions
            //collisions.luigiMario.Add(new Tuple<IMario, ICharacter, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.luigi, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), new CLuigiStuckX(sprint)));
            //collisions.luigiMario.Add(new Tuple<IMario, ICharacter, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.luigi, CollisionDictionary.Side.Right), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), new CLuigiStuckX(sprint)));
            //collisions.luigiMario.Add(new Tuple<IMario, ICharacter, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.luigi, CollisionDictionary.Side.Top), new Tuple<ICommand, ICommand>(new CMarioStuckY(sprint), new CLuigiStuckY(sprint)));
            //collisions.luigiMario.Add(new Tuple<IMario, ICharacter, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.luigi, CollisionDictionary.Side.Bottom), new Tuple<ICommand, ICommand>(new CMarioStuckY(sprint), new CLuigiStuckY(sprint)));

            // luigi block collisions
            //collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, sprint.objects.Blocks, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CLuigiStuckX(sprint), null));
            //collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, sprint.objects.Blocks, CollisionDictionary.Side.Right), new Tuple<ICommand, ICommand>(new CLuigiStuckX(sprint), null));
            //collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, sprint.objects.Blocks, CollisionDictionary.Side.Top), new Tuple<ICommand, ICommand>(new CLuigiStuckY(sprint), null));
            //collisions.luigiBlock.Add(new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(sprint.objects.luigi, sprint.objects.Blocks, CollisionDictionary.Side.Bottom), new Tuple<ICommand, ICommand>(new CLuigiStuckY(sprint), null));

            // mario block collisions
            //collisions.marioBlock.Add(new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Blocks, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), null));
            //collisions.marioBlock.Add(new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Blocks, CollisionDictionary.Side.Right), new Tuple<ICommand, ICommand>(new CMarioStuckX(sprint), null));
            //collisions.marioBlock.Add(new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Blocks, CollisionDictionary.Side.Top), new Tuple<ICommand, ICommand>(new CMarioStuckY(sprint), null));
            //collisions.marioBlock.Add(new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Blocks, CollisionDictionary.Side.Bottom), new Tuple<ICommand, ICommand>(new CMarioStuckY(sprint), null));

            // mario enemy collision
            //collisions.marioEnemy.Add(new Tuple<IMario, List<IEnemies>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Enemies, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CMarioTakeDamage(sprint), null));
            //collisions.marioEnemy.Add(new Tuple<IMario, List<IEnemies>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Enemies, CollisionDictionary.Side.Right), new Tuple<ICommand, ICommand>(new CMarioTakeDamage(sprint), null));

            // mario item collision
            //collisions.marioItem.Add(new Tuple<IMario, List<IItem>, CollisionDictionary.Side>(sprint.objects.mario, sprint.objects.Items, CollisionDictionary.Side.Any), new Tuple<ICommand, ICommand>(null, new CItemDisappear(sprint)));

            // item block collision
            //collisions.itemBlock.Add(new Tuple<List<IItem>, List<IBlock>, CollisionDictionary.Side>(sprint.objects.Items, sprint.objects.Blocks, CollisionDictionary.Side.Left), new Tuple<ICommand, ICommand>(new CItemBlockX(sprint), null));
            //collisions.itemBlock.Add(new Tuple<List<IItem>, List<IBlock>, CollisionDictionary.Side>(sprint.objects.Items, sprint.objects.Blocks, CollisionDictionary.Side.Right), new Tuple<ICommand, ICommand>(new CItemBlockX(sprint), null));

            //new collision hanndler
            //mario luigi collision
            collisions.collision.Add((typeof(Mario), typeof(Luigi), CollisionDictionary.Side.Left), luigiStuckX);
            collisions.collision.Add((typeof(Mario), typeof(Luigi), CollisionDictionary.Side.Right), luigiStuckX);
            collisions.collision.Add((typeof(Mario), typeof(Luigi), CollisionDictionary.Side.Top), luigiStuckY);
            collisions.collision.Add((typeof(Mario), typeof(Luigi), CollisionDictionary.Side.Bottom), luigiStuckY);

            //luigi static block collision
            collisions.collision.Add((typeof(Luigi), typeof(Clouds), CollisionDictionary.Side.Left), );
            collisions.collision.Add((typeof(Luigi), typeof(Clouds), CollisionDictionary.Side.Right), );
            collisions.collision.Add((typeof(Luigi), typeof(Clouds), CollisionDictionary.Side.Top), );
            collisions.collision.Add((typeof(Luigi), typeof(Clouds), CollisionDictionary.Side.Bottom), );
            collisions.collision.Add((typeof(Luigi), typeof(Floor), CollisionDictionary.Side.Top), );
            collisions.collision.Add((typeof(Luigi), typeof(LargeBlock), CollisionDictionary.Side.Left), );
            collisions.collision.Add((typeof(Luigi), typeof(LargeBlock), CollisionDictionary.Side.Right), );
            collisions.collision.Add((typeof(Luigi), typeof(LargeBlock), CollisionDictionary.Side.Top), );
            collisions.collision.Add((typeof(Luigi), typeof(LargeBlock), CollisionDictionary.Side.Bottom), );
            collisions.luigiBlock1.Add((sprint.objects.luigi, (IBlock)sprint.objects.StaticEntities, CollisionDictionary.Side.Right), (new CLuigiStuckX(sprint), null));
            collisions.luigiBlock1.Add((sprint.objects.luigi, (IBlock)sprint.objects.StaticEntities, CollisionDictionary.Side.Top), (new CLuigiStuckY(sprint), null));
            collisions.luigiBlock1.Add((sprint.objects.luigi, (IBlock)sprint.objects.StaticEntities, CollisionDictionary.Side.Bottom), (new CLuigiStuckY(sprint), null));

            //luigi dynamic block collision
            collisions.luigiBlock1.Add((sprint.objects.luigi, (IBlock)sprint.objects.DynamicEntities, CollisionDictionary.Side.Left), (new CLuigiStuckX(sprint), null));
            collisions.luigiBlock1.Add((sprint.objects.luigi, (IBlock)sprint.objects.DynamicEntities, CollisionDictionary.Side.Right), (new CLuigiStuckX(sprint), null));
            collisions.luigiBlock1.Add((sprint.objects.luigi, (IBlock)sprint.objects.DynamicEntities, CollisionDictionary.Side.Top), (new CLuigiStuckY(sprint), null));
            collisions.luigiBlock1.Add((sprint.objects.luigi, (IBlock)sprint.objects.DynamicEntities, CollisionDictionary.Side.Bottom), (new CLuigiStuckY(sprint), null)); //break block command, block to entities to be removed, change to dull block for question
            
            //luigi attack block collision


            //luigi item collision
            collisions.luigiItem1.Add((sprint.objects.luigi, (IItem)sprint.objects.DynamicEntities, CollisionDictionary.Side.Any), (null, null)); //make luigi change state command and item to entities to be removed

            //mario block collision
            collisions.marioBlock1.Add();

            //mario attack block collision

            //mario enemy collision
            collisions.marioEnemy1.Add((sprint.objects.mario, (IEnemies)sprint.objects.DynamicEntities, CollisionDictionary.Side.Left), (null, null)); //item disappear

            //mario item collision
            collisions.marioItem1.Add((sprint.objects.mario, (IItem)sprint.objects.DynamicEntities, CollisionDictionary.Side.Any), (null, null));

            //item block collision
            collisions.itemBlock1.Add();

            //enemy block collision
            collisions.enemyBlock1.Add();
        }

        private static void callLuigiStuckX(IEntity entity1, IEntity entity2)
        {
            CLuigiStuckX CStuckX = new CLuigiStuckX((ICharacter)entity1);
            CStuckX.Execute();
        }

        private static void callLuigiStuckY(IEntity entity1, IEntity entity2)
        {
            CLuigiStuckY CStuckY = new CLuigiStuckY((ICharacter)entity1);
            CStuckY.Execute();
        }
    }
}