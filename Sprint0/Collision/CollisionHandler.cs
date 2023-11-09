using Microsoft.Xna.Framework;
using Sprint0.Commands.Collisions;
using Sprint0.GameMangager;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;

namespace Sprint0.Collision
{
    public class CollisionHandler
    {
        public Sprint0 sprint;

        List<IEnemies> Enemies;
        List<IItem> Items;
        List<IBlock> Blocks, TopCollidableBlocks, BottomCollidableBlocks, SideCollidableBlocks;
        CollisionDictionraryRegister register;
        ObjectManager objectManager;
        Rectangle blockHitbox;
        ICharacter luigi;
        IMario mario;

        public CollisionHandler(Sprint0 sprint, ObjectManager objects)
        { 
            this.sprint = sprint;
            this.objectManager = objects;

            Enemies = objects.Enemies;
            Items = objects.Items;
            Blocks = objects.Blocks;
          
            TopCollidableBlocks = objects.TopCollidableBlocks;
            BottomCollidableBlocks = objects.BottomCollidableBlocks;
            SideCollidableBlocks = objects.SideCollidableBlocks;

            luigi = objects.luigi;
            mario = objects.mario;

            register = new CollisionDictionraryRegister(sprint);

            register.generate();
        }

        /*
        public void luigiBlockUpdate()
        {
            foreach (IBlock block in Blocks)
            {
                blockHitbox = new Rectangle(block.x, block.y, block.width, block.height);

                if (luigi.destination.Intersects(blockHitbox))
                {
                    //register.collisions.playerBlockDict[new Tuple<List<ICharacter>, List<IBlock>, CollisionDictionary.Side>(Players, Blocks, CollisionDictionary.Side.Top)].Item1.Execute();

                    if (Rectangle.Intersect(luigi.destination, blockHitbox).Width >= Rectangle.Intersect(luigi.destination, blockHitbox).Height)
                    {
                        if (blockHitbox.Y > luigi.destination.Y)
                        {
                            if (TopCollidableBlocks.Contains(block))
                            {
                                register.collisions.luigiBlock[new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(luigi, Blocks, CollisionDictionary.Side.Top)].Item1.Execute();
                            }
                        }

                        else if (blockHitbox.Y < luigi.destination.Y)
                        {
                            if (BottomCollidableBlocks.Contains(block))
                            {
                                register.collisions.luigiBlock[new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(luigi, Blocks, CollisionDictionary.Side.Bottom)].Item1.Execute();
                            }
                        }
                    }

                    else
                    {
                        if (SideCollidableBlocks.Contains(block))
                        {
                            if (blockHitbox.X > luigi.destination.X)
                            {
                                register.collisions.luigiBlock[new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(luigi, Blocks, CollisionDictionary.Side.Left)].Item1.Execute();
                            }

                            else if (blockHitbox.X < luigi.destination.X)
                            {
                                register.collisions.luigiBlock[new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(luigi, Blocks, CollisionDictionary.Side.Right)].Item1.Execute();
                            }
                        }
                    }
                }
            }
        }

        public void marioLuigiUpdate()
        {
            if (mario.destination.Intersects(luigi.destination))
            {
                // if objects hit on x axis (left or right)
                if (Rectangle.Intersect(mario.destination, luigi.destination).Width <= Rectangle.Intersect(mario.destination, luigi.destination).Height)
                {
                    register.collisions.luigiMario[new Tuple<IMario, ICharacter, CollisionDictionary.Side>(mario, luigi, CollisionDictionary.Side.Left)].Item1.Execute();
                    register.collisions.luigiMario[new Tuple<IMario, ICharacter, CollisionDictionary.Side>(mario, luigi, CollisionDictionary.Side.Left)].Item2.Execute();
                }
            }
        }
      
        public void marioEnemyUpdate()
        {
            foreach(IEnemies enemy in Enemies)
            {
                if (mario.destination.Intersects(enemy.destination))
                {
                    // if object hit on x axis (left or right)
                    if (Rectangle.Intersect(mario.destination, enemy.destination).Width <= Rectangle.Intersect(mario.destination, enemy.destination).Height && !mario.isInvinsible)
                    {
                        register.collisions.marioEnemy[new Tuple<IMario, List<IEnemies>, CollisionDictionary.Side>(mario, Enemies, CollisionDictionary.Side.Left)].Item1.Execute();
                        System.Diagnostics.Debug.WriteLine("Mario hit enemy");
                    }
                }
            }
        }

        public void marioBlockUpdate()
        {

            foreach (IBlock block in Blocks)
            {
                blockHitbox = new Rectangle(block.x, block.y, block.width, block.height);

                if (mario.destination.Intersects(blockHitbox))
                {
                    //register.collisions.playerBlockDict[new Tuple<List<ICharacter>, List<IBlock>, CollisionDictionary.Side>(Players, Blocks, CollisionDictionary.Side.Top)].Item1.Execute();


                    if (Rectangle.Intersect(mario.destination, blockHitbox).Width >= Rectangle.Intersect(mario.destination, blockHitbox).Height)
                    {
                        if (blockHitbox.Y > mario.destination.Y)
                        {
                            if (TopCollidableBlocks.Contains(block))
                            {
                                register.collisions.marioBlock[new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(mario, Blocks, CollisionDictionary.Side.Top)].Item1.Execute();
                            }
                        }

                        else if (blockHitbox.Y < mario.destination.Y)
                        {
                            if (BottomCollidableBlocks.Contains(block))
                            {
                                register.collisions.marioBlock[new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(mario, Blocks, CollisionDictionary.Side.Bottom)].Item1.Execute();
                            }
                        }
                    }


                    else
                    {
                        if (SideCollidableBlocks.Contains(block))
                        {
                            if (blockHitbox.X > mario.destination.X)
                            {
                                register.collisions.marioBlock[new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(mario, Blocks, CollisionDictionary.Side.Left)].Item1.Execute();
                            }

                            else if (blockHitbox.X < mario.destination.X)
                            {
                                register.collisions.marioBlock[new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(mario, Blocks, CollisionDictionary.Side.Right)].Item1.Execute();
                            }
                        }
                    }

                }

            }
        }

        public void marioItemUpdate()
        {
            foreach(IItem item in Items)
            {
                if (mario.destination.Intersects(item.destination))
                {
                    ICommand powerUp = new CMarioPowerUp(sprint, item);
                    powerUp.Execute();
                    register.collisions.marioItem[new Tuple<IMario, List<IItem>, CollisionDictionary.Side>(mario, Items, CollisionDictionary.Side.Any)].Item2.Execute();
                }
               
            }
        }
        */

        public void Update()
        {
            for (int i = 0; i < objectManager.DynamicEntities.Count; i++)
            {
                IEntity entity1 = objectManager.DynamicEntities[i];

                for (int j = i + 1; j < objectManager.DynamicEntities.Count; j++)
                {
                    IEntity entity2 = objectManager.DynamicEntities[j];

                    if (entity1.destination.Intersects(entity2.destination))
                    {
                        
                    }
                }

                foreach (IEntity sEntity in objectManager.StaticEntities)
                {
                    if (entity1.destination.Intersects(sEntity.destination))
                    {

                    }
                }
            }
        }
    }
}
