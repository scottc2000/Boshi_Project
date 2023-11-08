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
        List<IBlock> Blocks, TopCollidableBlocks, BottomCollidableBlocks, SideCollidableBlocks, Coins;
        CollisionDictionraryRegister register;
        Rectangle blockHitbox;
        ICharacter luigi;
        IMario mario;

        public CollisionHandler(Sprint0 sprint, ObjectManager objects)
        { 
            this.sprint = sprint;

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

        public void luigiBlockUpdate()
        {
            foreach (IBlock block in Blocks)
            {
                blockHitbox = new Rectangle(block.x, block.y, block.width, block.height);

                if (SideCollidableBlocks.Contains(block))
                {
                    register.collisions.luigiBlock[new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(luigi, Blocks, CollisionDictionary.Side.Left)].Item1.Execute(blockHitbox);

                }

                if (TopCollidableBlocks.Contains(block) || BottomCollidableBlocks.Contains(block))
                {
                    register.collisions.luigiBlock[new Tuple<ICharacter, List<IBlock>, CollisionDictionary.Side>(luigi, Blocks, CollisionDictionary.Side.Top)].Item1.Execute(blockHitbox);
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

                if (SideCollidableBlocks.Contains(block))
                {
                    register.collisions.marioBlock[new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(mario, Blocks, CollisionDictionary.Side.Left)].Item1.Execute(blockHitbox);

                }

                if (TopCollidableBlocks.Contains(block) || BottomCollidableBlocks.Contains(block))
                {
                    register.collisions.marioBlock[new Tuple<IMario, List<IBlock>, CollisionDictionary.Side>(mario, Blocks, CollisionDictionary.Side.Top)].Item1.Execute(blockHitbox);

                }
            }
        }

        public void marioItemUpdate()
        {
            foreach(IItem item in Items)
            {
                if (mario.destination.Intersects(item.itemRectangle))
                {
                    ICommand powerUp = new CMarioPowerUp(sprint, item);
                    powerUp.Execute();
                    register.collisions.marioItem[new Tuple<IMario, List<IItem>, CollisionDictionary.Side>(mario, Items, CollisionDictionary.Side.Any)].Item2.Execute();
                }
               
            }
        }

        public void itemBlockUpdate()
        {

           /* foreach(IItem item in Items)
            {
                foreach (IBlock block in Blocks)
                {
                    blockHitbox = new Rectangle(block.x, block.y, block.width, block.height);
                    if (item.itemRectangle.Intersects(blockHitbox))
                    {
                        //handles x collisions (left and right)
                        if (Rectangle.Intersect(item.itemRectangle, blockHitbox).Width <= Rectangle.Intersect(item.itemRectangle, blockHitbox).Height)
                        {
                            register.collisions.itemBlock[new Tuple<List<IItem>, List<IBlock>, CollisionDictionary.Side>(Items, Blocks, CollisionDictionary.Side.Left)].Item1.Execute();
                            register.collisions.itemBlock[new Tuple<List<IItem>, List<IBlock>, CollisionDictionary.Side>(Items, Blocks, CollisionDictionary.Side.Right)].Item2.Execute();
                        }
                    }
                }

            }*/
        }

        public void Update()
        {
            luigiBlockUpdate();
            marioLuigiUpdate();
            marioEnemyUpdate();
            marioBlockUpdate();
            marioItemUpdate();
        }
    }
}
